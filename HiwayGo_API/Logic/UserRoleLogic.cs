using HiwayGo_API.Entity;
using HiwayGo_API.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public class UserRoleLogic : IUserRoleLogic
    {
        private readonly IUserRoleRepository _repo;

        public UserRoleLogic(IUserRoleRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserRole> CreateAsync(UserRole role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            return await _repo.InsertAsync(role);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _repo.SelectAllAsync();
        }

        public async Task<UserRole?> GetByIdAsync(Guid id)
        {
            return await _repo.SelectByIdAsync(id);
        }

        public async Task<UserRole?> GetByNameAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return null;
            return await _repo.GetByNameAsync(roleName);
        }

        public async Task UpdateAsync(UserRole role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            await _repo.UpdateAsync(role);
        }
    }
}