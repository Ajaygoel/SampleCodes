namespace AvnonDemo.Domain.Core
{
    /// <summary>
    /// This is the basecontainer for responses to the server from the application
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// If success is false, this is the raw error message eg stacktrace
        /// </summary>
        public string Exception { get; set; }

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(T data, string msg = "", bool success=true)
        {
            Success = success;
            Message = msg;
            Data = data;
        }
    }

    public class BaseResponse : BaseResponse<object>
    {
        
    }
}