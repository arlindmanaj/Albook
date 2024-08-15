using Albook.Models.Domain;
using Albook.Models.DTO;

namespace Albook.Repositories.Interface
{
    public interface IAuthService
    {
        Task<LoginResponse> AuthenticateAsync(LoginRequestDto request);
        Task<bool> RegisterAsync(RegisterRequestDto request);
    }

}
