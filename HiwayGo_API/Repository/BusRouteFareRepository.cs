using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public class BusRouteFareRepository : GenericRepository<BusRouteFare>, IBusRouteFareRepository
    {
        public BusRouteFareRepository(DataContext context) : base(context)
        {
        }

        public async Task<BusRouteFare?> GetLatestFareForRouteAsync(Guid routeId)
        {
            return await _context.BusRouteFares
                .Where(f => f.BusRouteId == routeId)
                .OrderByDescending(f => f.ActiveDate)
                .FirstOrDefaultAsync();
        }

        // CRUD convenience implementations
        public async Task<BusRouteFare> InsertAsync(BusRouteFare fare)
        {
            return await CreateAsync(fare);
        }

        public async Task<IEnumerable<BusRouteFare>> SelectAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<BusRouteFare?> SelectByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public new async Task UpdateAsync(BusRouteFare fare)
        {
            await base.UpdateAsync(fare);
        }

        public new async Task<bool> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }
    }
}
