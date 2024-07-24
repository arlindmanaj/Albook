using Albook.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
