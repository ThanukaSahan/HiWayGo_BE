using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace HiwayGo_API.Repository
{
    public class BusModelRepository : GenericRepository<BusModel>, IBusModelRepository
    {
        public BusModelRepository(DataContext context) : base(context)
        {
        }

        public async Task<BusModel?> GetByModelAsync(string model)
        {
            return await _context.BusModel.FirstOrDefaultAsync(m => m.Model == model);
        }

        // CRUD convenience implementations
        public async Task<BusModel> InsertAsync(BusModel model)
        {
            return await CreateAsync(model);
        }

        public async Task<IEnumerable<BusModel>> SelectAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<BusModel?> SelectByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public new async Task UpdateAsync(BusModel model)
        {
            await base.UpdateAsync(model);
        }

        public new async Task<bool> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }
    }
}
