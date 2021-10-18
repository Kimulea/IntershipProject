using System.Net;

namespace Bloomcoding.Common.Exceptions
{
    public class EntryNotFoundException : ApiException
    {
        public EntryNotFoundException(string message) : base(HttpStatusCode.BadRequest, message)
        {

        }
    }
}
