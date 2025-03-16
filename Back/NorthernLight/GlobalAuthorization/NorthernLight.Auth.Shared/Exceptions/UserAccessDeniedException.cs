namespace NorthernLight.Auth.Shared.Exceptions
{
    internal class UserAccessDeniedException : Exception
    {
        public UserAccessDeniedException(string message) : base(message)
        {
        }

        public UserAccessDeniedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
