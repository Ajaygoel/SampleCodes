namespace AvnonDemo.Domain.Core
{
    public static class ResponseFactory
    {
        public static BaseResponse Success(object data = null, string message = "")
        {
            return new BaseResponse
            {
                Message = message,
                Success = true,
                Data = data
            };
        }
        public static BaseResponse Error(string friendlyErrorMessage, string exception = "")
        {
            return new BaseResponse
            {
                Success = false,
                Message = friendlyErrorMessage,
                Exception = exception
            };
        }
        public static BaseResponse<T> SuccessForType<T>(T data = default(T), string message = "")
        {
            return new BaseResponse<T>
            {
                Message = message,
                Success = true,
                Data = data
            };
        }
        public static BaseResponse<T> ErrorForType<T>(string friendlyErrorMessage, string exception = "")
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = friendlyErrorMessage,
                Exception = exception
            };
        }
    }
}