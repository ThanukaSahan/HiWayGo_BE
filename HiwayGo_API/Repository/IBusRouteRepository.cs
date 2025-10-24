using HiwayGo_API.Entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public interface IBusRouteRepository : IGenericRepository<BusRoute>
    {
        Task<BusRoute?> GetByRouteNoAsync(string routeNo);

        // CRUD convenience
        Task<BusRoute> InsertAsync(BusRoute route);
        Task<IEnumerable<BusRoute>> SelectAllAsync();
        Task<BusRoute?> SelectByIdAsync(Guid id);
        Task UpdateAsync(BusRoute route);
        Task<bool> DeleteAsync(Guid id);
    }
}
