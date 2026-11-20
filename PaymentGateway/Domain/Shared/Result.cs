using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Shared
{
    public class Result<T>
    {
        public bool IsSuccessful { get; }
        public string Error { get; }
        public T Value { get; set; }

        public Result(bool isSuccessful, string error)
        {
            IsSuccessful = isSuccessful;
            Error = error;
        }

        public static Result<T> Success(T value) => new Result<T>(true, string.Empty) { Value = value };
        public static Result<T> Failure(string error) => new Result<T>(false, error);
    }
}
