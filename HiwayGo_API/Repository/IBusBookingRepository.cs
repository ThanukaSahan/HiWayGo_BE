using HiwayGo_API.Entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public interface IBusBookingRepository : IGenericRepository<BusBooking>
    {
        Task<int> CountBookingsForRouteAsync(Guid routeId);

        // expose bus routes retrieval
        Task<IEnumerable<BusRoute>> GetAllBusRouteAsync();

        // CRUD convenience
        Task<BusBooking> InsertAsync(BusBooking booking);
        Task<IEnumerable<BusBooking>> SelectAllAsync();
        Task<BusBooking?> SelectByIdAsync(Guid id);
        Task UpdateAsync(BusBooking booking);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<BusBooking>> SelectBookByAsync(Guid id);
    }
}
