namespace TaskManager.Models
{
    public class ApiResultModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
        public ApiResultModel(T data, string error = null)
        {
            this.Error = error;
            this.Data = data;
            this.Success = error == null;
        }
    }
}
