using System.Text.RegularExpressions;
using FluentValidation;
using NorthernLight.Auth.Domain.Models.Auth;
using NorthernLight.Auth.Shared.Exceptions;

namespace NorthernLight.Auth.Application.Models.FluentValidation
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .Must((model, email) =>
                {
                    if (string.IsNullOrEmpty(email))
                    {
                        throw new CustomValidationException("Email is required");
                    }
                    else if (!IsEmailValid(email))
                    {
                        throw new CustomValidationException("Wrong email format");
                    }

                    return true;
                });

            RuleFor(x => x.Password)
                .Must((model, password) =>
                {
                    if (!string.IsNullOrEmpty(password) && password.Length >= 8)
                    {
                        return true;
                    }

                    throw new CustomValidationException("Password is required and must be at least 8 characters long");
                });

            RuleFor(x => x.RepeatPassword)
                .Must((model, repeatPassword) =>
                {
                    if (repeatPassword == model.Password)
                    {
                        return true;
                    }

                    throw new CustomValidationException("Passwords don't match");
                });
        }

        private static bool IsEmailValid(string email)
        {
            const string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new(pattern);
            var match = regex.Match(email);
            return match.Success;
        }
    }
}