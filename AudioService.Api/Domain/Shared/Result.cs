namespace Domain.Shared
{
    public sealed class Result<T>
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }

        public Result(bool isSuccessful, T? value, string? errorMessage)
        {
            IsSuccessful = isSuccessful;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static Result<T> Failure(string errorMessage) => new Result<T>(false, default, errorMessage);
    }
}
