using System;
using System.Net;

namespace Bloomcoding.Common.Exceptions
{
    class ApiException : Exception
    {
        public HttpStatusCode Code { get; }

        public ApiException(HttpStatusCode code, string message) : base(message)
        {
            Code = code;
        }
    }
}
