using HiwayGo_API.Entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public interface IBusRouteFareRepository : IGenericRepository<BusRouteFare>
    {
        Task<BusRouteFare?> GetLatestFareForRouteAsync(Guid routeId);

        // CRUD convenience
        Task<BusRouteFare> InsertAsync(BusRouteFare fare);
        Task<IEnumerable<BusRouteFare>> SelectAllAsync();
        Task<BusRouteFare?> SelectByIdAsync(Guid id);
        Task UpdateAsync(BusRouteFare fare);
        Task<bool> DeleteAsync(Guid id);
    }
}
