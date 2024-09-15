using Albook.Models.Domain;
using Albook.Models.DTO;

namespace Albook.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> AuthenticateAsync(LoginRequestDto request);
        Task<bool> RegisterAsync(RegisterRequestDto request);
    }

}
