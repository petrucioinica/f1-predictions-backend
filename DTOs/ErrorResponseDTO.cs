namespace f1_predictions.DTOs
{
    public class ErrorResponseDto
    {
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }

        public ErrorResponseDto(string message, Dictionary<string, string[]>? errors = null)
        {
            Message = message;
            Errors = errors ?? new Dictionary<string, string[]>();
        }
    }
}
