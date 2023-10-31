namespace TailorWebApp.Utils.Exceptions
{
    public class ValidationException : GlobalException
    {
        public ValidationException(IReadOnlyDictionary<string, string> errorsDictionary)
            : base("One or more validation errors occurred", errorsDictionary)
        {
        }

        protected ValidationException() : base()
        {
        }

        protected ValidationException(string? message) : base(message)
        {
        }

        protected ValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ValidationException(
            string message,
            IReadOnlyDictionary<string, string> errorsDictionary) : base(message, errorsDictionary)
        {
        }

        protected ValidationException(string message, string key, string value) : base(message, key, value)
        {
        }
    }
}