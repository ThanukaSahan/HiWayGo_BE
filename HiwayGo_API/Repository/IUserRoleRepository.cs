using HiwayGo_API.Entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        Task<UserRole?> GetByNameAsync(string roleName);

        // CRUD convenience
        Task<UserRole> InsertAsync(UserRole role);
        Task<IEnumerable<UserRole>> SelectAllAsync();
        Task<UserRole?> SelectByIdAsync(Guid id);
        Task UpdateAsync(UserRole role);
        Task<bool> DeleteAsync(Guid id);
    }
}
