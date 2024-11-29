namespace SimpleBlog.Application.DTOs
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }

        public AuthResult(bool success, string message, string token)
        {
            Success = success;
            Message = message;
            Token = token;
        }
    }
}
