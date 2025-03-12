using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthernLight.Auth.Application.Services.Users.UserProfile.AddOrUpdateProfile;
using NorthernLight.Auth.Application.Services.Auth.Register;
using NorthernLight.Auth.Domain.Models.Auth;
using NorthernLight.Auth.Domain.Models.User;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.Exceptions;
using NorthernLight.Auth.Shared.Services;

namespace NorthernLight.Auth.Application.Services.Auth.GoogleLogIn
{
    public class GoogleLogInService : IGoogleLogInService
    {
        private static string? _audience;

        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IRegisterService _registerService;
        private readonly IAddOrUpdateProfileService _addOrUpdateProfileService;
        private readonly IRepository<RefreshToken> _refreshTokenRepository;
        private readonly IRepository<VwUserSignInResponse> _vwUserSignInResponseRepository;

        public GoogleLogInService(IRepository<User> userRepository, IConfiguration configuration,
            IRegisterService registerService, IAddOrUpdateProfileService addOrUpdateProfileService,
            IRepository<RefreshToken> refreshTokenRepository,
            IRepository<VwUserSignInResponse> vwUserSignInResponseRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _registerService = registerService;
            _addOrUpdateProfileService = addOrUpdateProfileService;
            _refreshTokenRepository = refreshTokenRepository;
            _vwUserSignInResponseRepository = vwUserSignInResponseRepository;
            _audience = _configuration["GoogleAuth:ClientId"];
        }

        public async Task<ServiceResult<LoginResponse>> Execute(string googleAccessToken,
            CancellationToken cancellationToken)
        {
            using var httpClient = new HttpClient();
            var isTokenValid = await ValidateAccessToken(httpClient, googleAccessToken).ConfigureAwait(false);

            if (isTokenValid == true)
            {
                const string requestUri = "https://www.googleapis.com/oauth2/v1/userinfo";
                using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", googleAccessToken);
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    var deserializeUserGmailInfo =
                        JsonConvert.DeserializeObject<GoogleDeserializedUserInfoResult>(content) ??
                        throw new ArgumentException("MAIL_USERINFO_VALIDATION_ERROR");
                    var emailExists = await CheckIfMailExists(deserializeUserGmailInfo!.Email, cancellationToken)
                        .ConfigureAwait(false);

                    if (emailExists == true)
                    {
                        return await GetAccessTokenAsync(deserializeUserGmailInfo, cancellationToken)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        //დასამატებელია ვალიდაცია, უნდა შეიძლებოდეს თუ არა რეგისტრაცია დაუმატებელი კლიენტების
                        var generateRandomPassword = PasswordGenerator.GenerateSecurePassword(12);

                        var registerParam = new RegisterDto()
                        {
                            Email = deserializeUserGmailInfo.Email,
                            Password = generateRandomPassword,
                            RepeatPassword = generateRandomPassword
                        };

                        var registeredUserGuid = (await _registerService.Execute(registerParam, cancellationToken)
                            .ConfigureAwait(false)).Data;

                        var userProfile = new UserProfileDTO()
                        {
                            UserId = registeredUserGuid,
                            Firstname = deserializeUserGmailInfo.GivenName,
                            Lastname = deserializeUserGmailInfo.FamilyName
                        };
                        await _addOrUpdateProfileService.Execute(userProfile, cancellationToken).ConfigureAwait(false);

                        return await GetAccessTokenAsync(deserializeUserGmailInfo, cancellationToken)
                            .ConfigureAwait(false);
                    }
                }
                else
                {
                    throw new ArgumentException("MAIL_USERINFO_VALIDATION_ERROR");
                }
            }

            throw new ArgumentException("MAIL_VALIDATION_ERROR");
        }


        private async Task<ServiceResult<LoginResponse>> GetAccessTokenAsync(
            GoogleDeserializedUserInfoResult deserializedUserGmailInfo, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Where(x => x.Email == deserializedUserGmailInfo.Email)
                .FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            var jwtSecret = _configuration["Jwt:Secret"] ?? throw new NotFoundException("Jwt Secret Key not found");

            var generateToken = GenerateJwtToken(user, jwtSecret, false);
            var generateRefreshToken = GenerateJwtToken(user, jwtSecret, true);

            var checkRefreshTokenIfExists = await _refreshTokenRepository
                .FirstOrDefaultAsync(x => x.UserId == user.Id, cancellationToken).ConfigureAwait(false);
            if (checkRefreshTokenIfExists != null)
            {
                checkRefreshTokenIfExists.Token = generateRefreshToken.Item1;
                checkRefreshTokenIfExists.ExpiryDate = generateRefreshToken.Item2;
            }
            else
            {
                var refreshTokenObject = new RefreshToken()
                {
                    UserId = user.Id,
                    Token = generateRefreshToken.Item1,
                    ExpiryDate = generateRefreshToken.Item2
                };
                await _refreshTokenRepository.Add(refreshTokenObject, cancellationToken).ConfigureAwait(false);
            }


            var getUser = await _vwUserSignInResponseRepository.Where(x => x.Id == user.Id).Select(op =>
                new LoginResponse()
                {
                    AccessToken = generateToken.Item1
                }).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

            return getUser == null
                ? throw new NotFoundException("USER_NOT_FOUND")
                : ServiceResult<LoginResponse>.SuccessResult(getUser);
        }

        private static (string, DateTime) GenerateJwtToken(User user, string jwtSecret, bool isRefreshToken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSecret ?? "");

            var expireDate = isRefreshToken ? DateTime.UtcNow.AddHours(24) : DateTime.UtcNow.AddMinutes(5);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),

                Expires = expireDate,
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return (jwtTokenHandler.WriteToken(token), expireDate);
        }

        private async Task<bool> CheckIfMailExists(string mail, CancellationToken cancellationToken) =>
            await _userRepository.AnyAsync(x => x.Email == mail, cancellationToken).ConfigureAwait(false);

        private static async Task<bool> ValidateAccessToken(HttpClient httpClient, string accessToken)
        {
            var response = await httpClient
                .GetAsync($"https://www.googleapis.com/oauth2/v3/tokeninfo?access_token={accessToken}")
                .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var validationResult = JsonConvert.DeserializeObject<GoogleTokenValidationResult>(content);
                return validationResult == null
                    ? throw new ArgumentException("MAIL_VALIDATION_ERROR")
                    : validationResult.Aud == _audience && IsTokenExpired(validationResult.Exp) == false;
            }

            return false;
        }

        private static bool IsTokenExpired(string expTimestamp)
        {
            if (long.TryParse(expTimestamp, out var expValue))
            {
                var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(expValue);
                var tokenExpiration = dateTimeOffset.LocalDateTime;

                if (DateTime.Now < tokenExpiration)
                {
                    return false;
                }
            }

            return true;
        }
    }
}