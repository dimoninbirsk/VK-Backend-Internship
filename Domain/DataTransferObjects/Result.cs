namespace VKBackendInternship.Domain.DataTransferObjects
{
    public class Result<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
