namespace Tubes.Core
{
    public class OperationResult
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }
        private OperationResult(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
        public static OperationResult Success() => new OperationResult(true, string.Empty);
        public static OperationResult Fail(string message) => new OperationResult(false, message);
    }
}
