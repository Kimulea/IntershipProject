using System.Net;

namespace Bloomcoding.Common.Exceptions
{
    public class NullException : ApiException
    {
        public NullException(string message) : base(HttpStatusCode.BadRequest, message)
        {

        }
    }
}
