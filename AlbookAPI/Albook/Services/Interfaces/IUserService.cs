using Albook.Models.Domain;

namespace Albook.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<bool> AddUserAsync(User model);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> ChangeUserRoleAsync(int id, string newRole, string newUsername);
    }
}
