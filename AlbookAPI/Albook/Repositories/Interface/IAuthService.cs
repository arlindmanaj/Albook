using Albook.Models.DTO;

namespace Albook.Repositories.Interface
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(LoginRequestDto request);
        Task<bool> RegisterAsync(RegisterRequestDto request);
    }

}
