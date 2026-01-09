using HiwayGo_API.Entity;
using HiwayGo_API.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public class BusBookingLogic : IBusBookingLogic
    {
        private readonly IBusBookingRepository _repo;

        public BusBookingLogic(IBusBookingRepository repo)
        {
            _repo = repo;
        }

        public async Task<BusBooking> CreateAsync(BusBooking booking)
        {
            if (booking == null) throw new ArgumentNullException(nameof(booking));
            return await _repo.InsertAsync(booking);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<BusBooking>> GetAllAsync()
        {
            return await _repo.SelectAllAsync();
        }

        public async Task<BusBooking?> GetByIdAsync(Guid id)
        {
            return await _repo.SelectByIdAsync(id);
        }

        public async Task<int> CountBookingsForRouteAsync(Guid routeId)
        {
            return await _repo.CountBookingsForRouteAsync(routeId);
        }

        public async Task UpdateAsync(BusBooking booking)
        {
            if (booking == null) throw new ArgumentNullException(nameof(booking));
            await _repo.UpdateAsync(booking);
        }
    }
}