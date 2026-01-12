using HiwayGo_API.Entity;
using HiwayGo_API.Mapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public interface IUserRoleLogic
    {
        // GET methods return DTOs
        Task<IEnumerable<UserRoleDto>> GetAllAsync();
        Task<UserRoleDto?> GetByIdAsync(Guid id);
        Task<UserRoleDto?> GetByNameAsync(string roleName);

        // Create/Update/Delete continue to use the entity
        Task<UserRole> CreateAsync(UserRole role);
        Task UpdateAsync(UserRole role);
        Task<bool> DeleteAsync(Guid id);
    }
}