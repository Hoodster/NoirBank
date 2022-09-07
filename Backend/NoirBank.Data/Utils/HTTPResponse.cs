using System;
using System.Net;

namespace NoirBank.Data.Utils
{
    public class HTTPResponse
    {
        public int Status { get; set; }
        public object Data { get; set; }

        public HTTPResponse(HttpStatusCode statusCode, string message, bool isError = true)
        {
            Status = (int)statusCode;
            Data = new
            {
                Type = isError ? "error" : "response",
                Message = message
            };
        }

        public HTTPResponse(HttpStatusCode statusCode, object body)
        {
            Status = (int)statusCode;
            Data = body;
        }
    }
}

