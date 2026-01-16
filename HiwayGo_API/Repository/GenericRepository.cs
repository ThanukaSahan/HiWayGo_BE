using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Convenience CRUD implementations
        public async Task<T> CreateAsync(T entity)
        {
            await AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entityToUpdate)
        {
            Update(entityToUpdate);
            await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;
            Remove(entity);
            await SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BusRoute>> GetAllBusRouteAsync()
        {
            return await _context.Set<BusRoute>().ToListAsync();
        }
    }
}
