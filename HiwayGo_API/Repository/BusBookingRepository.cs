using HiwayGo_API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace HiwayGo_API.Repository
{
    public class BusBookingRepository : GenericRepository<BusBooking>, IBusBookingRepository
    {
        public BusBookingRepository(DataContext context) : base(context)
        {
        }

        public async Task<int> CountBookingsForRouteAsync(Guid routeId)
        {
            return await _context.BusBookings.CountAsync(b => b.BusRouteId == routeId);
        }

        public async Task<IEnumerable<BusRoute>> GetAllBusRouteAsync()
        {
            return await _context.Set<BusRoute>().ToListAsync();
        }

        // CRUD convenience implementations
        public async Task<BusBooking> InsertAsync(BusBooking booking)
        {
            return await CreateAsync(booking);
        }

        public async Task<IEnumerable<BusBooking>> SelectAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<BusBooking?> SelectByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public new async Task UpdateAsync(BusBooking booking)
        {
            await base.UpdateAsync(booking);
        }

        public new async Task<bool> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }

        public async Task<IEnumerable<BusBooking>> SelectBookByAsync(Guid id)
        {
            var busBookinghs = await SelectAllAsync();
            return busBookinghs.Where(b => b.BookBy == id);            
        }
    }
}
