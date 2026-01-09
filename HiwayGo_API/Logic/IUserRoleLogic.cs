using HiwayGo_API.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public interface IUserRoleLogic
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole?> GetByIdAsync(Guid id);
        Task<UserRole?> GetByNameAsync(string roleName);
        Task<UserRole> CreateAsync(UserRole role);
        Task UpdateAsync(UserRole role);
        Task<bool> DeleteAsync(Guid id);
    }
}