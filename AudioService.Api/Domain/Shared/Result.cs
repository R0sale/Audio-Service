using Domain.Errors;

namespace Domain.Shared
{
    public sealed class Result<T>
    {
        public bool IsSuccessful { get; }
        public Error? ErrorMessage { get; }
        public T? Value { get; }

        private Result(bool isSuccessful, T? value, Error? error)
        {
            IsSuccessful = isSuccessful;
            Value = value;
            ErrorMessage = error;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static Result<T> Failure(Error? error) => new Result<T>(false, default, error);
    }
}
