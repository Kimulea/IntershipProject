using System.Net;

namespace Bloomcoding.Common.Exceptions
{
    class EntryNotFoundException : ApiException
    {
        public EntryNotFoundException(string message) : base(HttpStatusCode.BadRequest, message)
        {

        }
    }
}
