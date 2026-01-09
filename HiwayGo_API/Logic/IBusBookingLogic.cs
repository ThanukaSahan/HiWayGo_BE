using HiwayGo_API.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public interface IBusBookingLogic
    {
        Task<IEnumerable<BusBooking>> GetAllAsync();
        Task<BusBooking?> GetByIdAsync(Guid id);
        Task<int> CountBookingsForRouteAsync(Guid routeId);
        Task<BusBooking> CreateAsync(BusBooking booking);
        Task UpdateAsync(BusBooking booking);
        Task<bool> DeleteAsync(Guid id);
    }
}