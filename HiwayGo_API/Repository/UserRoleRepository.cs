using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace HiwayGo_API.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DataContext context) : base(context)
        {
        }

        public async Task<UserRole?> GetByNameAsync(string roleName)
        {
            return await _context.userRoles.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }

        // CRUD convenience implementations
        public async Task<UserRole> InsertAsync(UserRole role)
        {
            return await CreateAsync(role);
        }

        public async Task<IEnumerable<UserRole>> SelectAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<UserRole?> SelectByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public new async Task UpdateAsync(UserRole role)
        {
            await base.UpdateAsync(role);
        }

        public new async Task<bool> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }
    }
}
