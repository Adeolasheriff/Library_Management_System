namespace Library_Management_System.Application.DTO;

public class ErrorResponse
{
    public string Message { get; set; } = "An error occurred.";
    public object? Errors { get; set; }
    public int StatusCode { get; set; }
    public string Exception { get; set; } = string.Empty;
}