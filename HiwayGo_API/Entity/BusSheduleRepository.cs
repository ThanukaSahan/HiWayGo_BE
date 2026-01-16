using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Repository
{
    public class BusSheduleRepository : GenericRepository<BusShedule>, IBusSheduleRepository
    {
        public BusSheduleRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BusShedule>> SelectAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<BusShedule?> SelectByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<BusShedule> InsertAsync(BusShedule busShedule)
        {
            return await CreateAsync(busShedule);
        }

        public new async Task UpdateAsync(BusShedule busShedule)
        {
            await base.UpdateAsync(busShedule);
        }

        public new async Task<bool> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }
    }
}