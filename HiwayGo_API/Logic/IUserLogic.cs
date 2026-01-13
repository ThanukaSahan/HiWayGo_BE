using HiwayGo_API.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public interface IUserLogic
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByNicAsync(string nic);
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
        Task<bool> DeleteAsync(Guid id);

        Task<bool> ResetPasswordAsync(string nic, string newPassword);

        // Returns JWT token string when successful, null when authentication fails
        Task<string?> LoginAsync(string nic, string password);
    }
}