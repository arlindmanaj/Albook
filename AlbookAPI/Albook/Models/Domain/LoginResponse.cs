namespace Albook.Models.Domain
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string? Role { get; set; }
    }
}
