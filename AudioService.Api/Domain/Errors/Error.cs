using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Errors
{
    public abstract class Error
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public Error(string errorMessage, HttpStatusCode statusCode)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
