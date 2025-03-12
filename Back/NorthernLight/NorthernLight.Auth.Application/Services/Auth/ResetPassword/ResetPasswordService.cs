using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Persistence.Entities;
using NorthernLight.Auth.Persistence.Repository;
using NorthernLight.Auth.Shared.Exceptions;

namespace NorthernLight.Auth.Application.Services.Auth.ResetPassword
{
    public class ResetPasswordService(
        IRepository<User> userRepository,
        IConfiguration configuration)
        : IResetPasswordService
    {
        public async Task<ServiceResult<string>> Execute(string usernameOrEmail, CancellationToken cancellationToken)
        {
            var user = await userRepository
                .FirstOrDefaultAsync(x => x.Username == usernameOrEmail || x.Email == usernameOrEmail,
                    cancellationToken).ConfigureAwait(false) ?? throw new NotFoundException("WRONG_USERNAME");
            if (!(user.IsActive ?? false))
            {
                throw new ValidationException("BLOCKED_USER");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new NotFoundException("EMAIL_NOT_FOUND");
            }

            var secretKey = configuration["Jwt:PasswordRecoverySecretKey"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new NotFoundException("SECRET_KEY_NOT_FOUND");
            }

            var generatePasswordResetToken = GeneratePasswordResetToken(user.Id.ToString(), user.Email, secretKey);

            try
            {
                var generatedBody = GenerateMailBody(generatePasswordResetToken, "http://localhost:3000");

                SendEmail(user.Email, "TestApp - Reset Password", generatedBody);

                return ServiceResult<string>.SuccessResult(user.Email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string GeneratePasswordResetToken(string userId, string email, string secretKey)
        {
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId),
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15), // Set the token expiration time
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private void SendEmail(string toAddress, string subject, string body)
        {
            var fromAddress = new MailAddress("testcompanyaddr2024@gmail.com", "TestApp");
            var toAddressMail = new MailAddress(toAddress, "Recipient Name");
            const string fromPassword = "54865486Aleko";
            const string smtpHost = "smtp.gmail.com";
            const int smtpPort = 465;

            var smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;

            smtp.Host = smtpHost;
            smtp.Port = smtpPort;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);

            using var message = new MailMessage(fromAddress, toAddressMail);
            message.Subject = subject;
            message.Body = body;
            smtp.Send(message);
        }


        private static string GenerateMailBody(string token, string url)
        {
            var resetLink = $"{url}/auth/reset-password?userToken={Uri.EscapeDataString(token)}";

            var body =
                $"<html><body><p>To reset your password, please click the link below:</p><p><a href=\"{resetLink}\">Reset Password</a></p></body></html>";

            return body;
        }
    }
}