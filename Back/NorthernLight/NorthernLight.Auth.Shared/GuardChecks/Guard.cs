using NorthernLight.Auth.Domain.Shared;
using NorthernLight.Auth.Shared.Constants;
using NorthernLight.Auth.Shared.Exceptions;

namespace NorthernLight.Auth.Shared.GuardChecks
{
    public static class Guard
    {
        public static void NotNull<T>(T value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void NotNullOrEmpty(string? value, string paramName, string? message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    !string.IsNullOrEmpty(message) ? message : ExceptionMessageConstants.VALUE_NOT_FOUND, paramName);
            }
        }

        public static void UserPermited(bool isActive)
        {
            if (isActive != true)
            {
                throw new UserAccessDeniedException(ExceptionMessageConstants.USER_NOT_ALLOWED);
            }
        }

        public static void IncomingServiceCheck<T>(ServiceResult<T> result)
        {
            if (result.ErrorOccured == true)
            {
                throw new Exception(!string.IsNullOrEmpty(result.ErrorMessage)
                    ? result.ErrorMessage
                    : ExceptionMessageConstants.UNEXPECTED_ERROR);
            }
        }


        public static void RecordNotFoundCHeck<T>(T? record)
        {
            if (record == null)
            {
                throw new NotFoundException("RECORD_NOT_FOUND");
            }
        }

        public static void IdValidation(int? id)
        {
            if (id == null || id < 1)
            {
                throw new ArgumentException("WRONG_ID_VALUE");
            }
        }
    }
}