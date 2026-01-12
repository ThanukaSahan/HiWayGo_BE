using AutoMapper;
using HiwayGo_API.Entity;
using HiwayGo_API.Mapper;
using HiwayGo_API.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public class UserRoleLogic : IUserRoleLogic
    {
        private readonly IUserRoleRepository _repo;
        private readonly IMapper _mapper;

        public UserRoleLogic(IUserRoleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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

        public async Task<IEnumerable<UserRoleDto>> GetAllAsync()
        {
            var roles = await _repo.SelectAllAsync();
            return _mapper.Map<IEnumerable<UserRoleDto>>(roles.Where(x => x.Id != new Guid("a1952a8b-7b0d-4915-9494-e6c9065070ca")));
        }

        public async Task<UserRoleDto?> GetByIdAsync(Guid id)
        {
            var role = await _repo.SelectByIdAsync(id);
            return role == null ? null : _mapper.Map<UserRoleDto>(role);
        }

        public async Task<UserRoleDto?> GetByNameAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return null;
            var role = await _repo.GetByNameAsync(roleName);
            return role == null ? null : _mapper.Map<UserRoleDto>(role);
        }

        public async Task UpdateAsync(UserRole role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            await _repo.UpdateAsync(role);
        }
    }
}