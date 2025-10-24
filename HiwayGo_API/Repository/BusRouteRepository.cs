using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace HiwayGo_API.Repository
{
    public class BusRouteRepository : GenericRepository<BusRoute>, IBusRouteRepository
    {
        public BusRouteRepository(DataContext context) : base(context)
        {
        }

        public async Task<BusRoute?> GetByRouteNoAsync(string routeNo)
        {
            return await _context.BusRoutes.FirstOrDefaultAsync(r => r.RouteNo == routeNo);
        }

        // CRUD convenience implementations
        public async Task<BusRoute> InsertAsync(BusRoute route)
        {
            return await CreateAsync(route);
        }

        public async Task<IEnumerable<BusRoute>> SelectAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<BusRoute?> SelectByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public new async Task UpdateAsync(BusRoute route)
        {
            await base.UpdateAsync(route);
        }

        public new async Task<bool> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }
    }
}
