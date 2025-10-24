using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public class BusDetailRepository : GenericRepository<BusDetail>, IBusDetailRepository
    {
        public BusDetailRepository(DataContext context) : base(context)
        {
        }

        public async Task<BusDetail?> GetByOwnerAsync(Guid ownerId)
        {
            return await _context.BusDetails.FirstOrDefaultAsync(b => b.OwnerId == ownerId);
        }

        // CRUD convenience implementations
        public async Task<BusDetail> InsertAsync(BusDetail detail)
        {
            return await CreateAsync(detail);
        }

        public async Task<IEnumerable<BusDetail>> SelectAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<BusDetail?> SelectByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public new async Task UpdateAsync(BusDetail detail)
        {
            await base.UpdateAsync(detail);
        }

        public new async Task<bool> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }
    }
}
