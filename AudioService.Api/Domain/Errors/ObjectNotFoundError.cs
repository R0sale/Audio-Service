using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Errors
{
    public class ObjectNotFoundError : Error
    {
        public ObjectNotFoundError(string errorMessage, HttpStatusCode statusCode) : base(errorMessage, statusCode)
        { }
    }
}
