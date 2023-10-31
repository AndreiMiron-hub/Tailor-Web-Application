namespace TailorWebApp.Utils.Exceptions
{
    public abstract class GlobalException : Exception
    {
        public IReadOnlyDictionary<string, string>? ErrorsDictionary { get; }

        protected GlobalException() : base()
        {
        }

        protected GlobalException(string? message) : base(message)
        {
        }

        protected GlobalException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GlobalException(
            string message,
            IReadOnlyDictionary<string, string> errorsDictionary) : base(message)
        {
            ErrorsDictionary = errorsDictionary;
        }

        protected GlobalException(
            string message,
            string key, string value) : base(message)
        {
            ErrorsDictionary = new Dictionary<string, string>
            {
                { key, value }
            };
        }
    }
}