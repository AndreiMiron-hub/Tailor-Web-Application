using System.Net;
using TailorWebApp.Utils.Exceptions;

namespace TailorWebApp.Utils.Dictionaries
{
    public class ExceptionsStatusCodes
    {
        public readonly Dictionary<Type, HttpStatusCode> Exceptions;

        public ExceptionsStatusCodes()
        {
            Exceptions = new Dictionary<Type, HttpStatusCode>
            {
                { typeof(KeyNotFoundException), HttpStatusCode.NotFound },
                { typeof(UnauthorizedException), HttpStatusCode.Unauthorized },
                { typeof(Exception), HttpStatusCode.InternalServerError },
                //{ typeof(ValidationException), HttpStatusCode.BadRequest },
            };
        }
    }
}