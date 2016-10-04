using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientFramework.Entities
{
    public class Response
    {
        public bool IsSuccessful { get; private set; }
        public object ReturnValue { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public string Error { get; private set; }
        public Response(bool isSuccessful, object returnValue, HttpStatusCode statusCode, string error)
        {
            IsSuccessful = isSuccessful;
            ReturnValue = returnValue;
            StatusCode = statusCode;
            Error = error;
        }
    }
}
