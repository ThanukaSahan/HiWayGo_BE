using HiwayGo_API.Entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByNicAsync(string nic);

        // CRUD convenience
        Task<User> InsertAsync(User user);
        Task<IEnumerable<User>> SelectAllAsync();
        Task<User?> SelectByIdAsync(Guid id);
        Task UpdateAsync(User user);
        Task<bool> DeleteAsync(Guid id);

        Task<User?> GetByEmailAsync(string email);
    }
}
