using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Shared
{
    public class Result
    {
        public bool IsSuccessful { get; }
        public string Error { get; }

        public Result(bool isSuccessful, string error)
        {
            IsSuccessful = isSuccessful;
            Error = error;
        }

        public static Result Success() => new Result(true, string.Empty);
        public static Result Failure(string error) => new Result(false, error);
    }
}
