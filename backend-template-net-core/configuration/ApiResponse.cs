namespace backend_template_net_core.configuration
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; } = default!;
    }
}
