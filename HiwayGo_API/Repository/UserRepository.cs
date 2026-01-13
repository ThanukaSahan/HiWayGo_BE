using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<User?> GetByNicAsync(string nic)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.NIC == nic);
        }

        // CRUD convenience implementations
        public async Task<User> InsertAsync(User user)
        {
            return await CreateAsync(user);
        }

        public async Task<IEnumerable<User>> SelectAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<User?> SelectByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public new async Task UpdateAsync(User user)
        {
            await base.UpdateAsync(user);
        }

        public new async Task<bool> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
