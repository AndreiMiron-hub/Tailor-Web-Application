namespace TailorWebApp.Utils.Exceptions
{
    public class UnauthorizedException : GlobalException
    {
        public UnauthorizedException(string? message) : base(message)
        {
        }

        public UnauthorizedException(string key, string value, string message)
            : base(message, key, value)
        {
        }

        protected UnauthorizedException() : base()
        {
        }

        protected UnauthorizedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedException(
            string message,
            IReadOnlyDictionary<string, string> errorsDictionary) : base(message, errorsDictionary)
        {
        }
    }
}