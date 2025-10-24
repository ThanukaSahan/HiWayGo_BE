using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveChangesAsync();

        // Convenience CRUD operations
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entityToUpdate);
        Task<bool> DeleteAsync(Guid id);
    }
}
