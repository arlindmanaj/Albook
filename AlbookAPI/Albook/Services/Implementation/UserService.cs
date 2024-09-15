using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Albook.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using Albook.Services.Implementation;
using Albook.Services.Interfaces;

namespace Albook.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = _userRepository.GetAllUsers();
            return users.Select(user => new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role
            });
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;

            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role
            };
        }

        public async Task<bool> AddUserAsync(User model)
        {
            var user = new User
            {
                Username = model.Username,
                PasswordHash = model.PasswordHash, // Remember to hash passwords
                Role = model.Role,
                Email = model.Email
            };

            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return false;

            await _userRepository.DeleteUserAsync(user);
            return true;
        }
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
        public async Task<bool> ChangeUserRoleAsync(int id, string newRole, string newUsername)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return false;

            user.Role = newRole;
            user.Username = newUsername;
            await _userRepository.UpdateUserAsync(user);
            return true;
        }
    }
}