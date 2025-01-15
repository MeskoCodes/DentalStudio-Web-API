namespace Contract
{
    public class GeneralResponseDto
    {
        public object? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
    }
}