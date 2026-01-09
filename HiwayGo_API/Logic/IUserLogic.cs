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
    }
}