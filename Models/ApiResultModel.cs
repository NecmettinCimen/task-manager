namespace TaskManager.Models
{
    public class ApiResultModel<T>
    {
        public ApiResultModel(T data, string error = null)
        {
            Error = error;
            Data = data;
            Success = error == null;
        }

        public bool Success { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
    }
}