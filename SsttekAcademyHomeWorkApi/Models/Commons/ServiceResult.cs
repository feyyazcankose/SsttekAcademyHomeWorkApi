namespace SsttekAcademyHomeWorkApi.Models.Commons
{
    // Non-Generic ServiceResult
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ServiceResult()
        {
            Errors = new List<string>();
        }

        public static ServiceResult SuccessResult(string message = "İşlem başarılı.")
        {
            return new ServiceResult { Success = true, Message = message };
        }

        public static ServiceResult ErrorResult(string message = "Bir hata oluştu.", List<string> errors = null)
        {
            return new ServiceResult { Success = false, Message = message, Errors = errors ?? new List<string>() };
        }
    }

    // Generic ServiceResult<T>
    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }

        public static ServiceResult<T> SuccessResult(T data, string message = "İşlem başarılı.")
        {
            return new ServiceResult<T> { Success = true, Data = data, Message = message };
        }

        public static ServiceResult<T> ErrorResult(string message = "Bir hata oluştu.", List<string> errors = null)
        {
            return new ServiceResult<T> { Success = false, Message = message, Errors = errors ?? new List<string>() };
        }
    }
}