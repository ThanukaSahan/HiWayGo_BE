using HiwayGo_API.DTO;
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
        private readonly IBusSheduleRepository _shedul;

        public BusBookingLogic(IBusBookingRepository repo, IBusSheduleRepository shedul)
        {
            _repo = repo;
            _shedul = shedul;
        }

        public async Task<BusBooking> CreateAsync(BusBooking booking)
        {
            if (booking == null) throw new ArgumentNullException(nameof(booking));
            if (string.IsNullOrWhiteSpace(booking.PickupLocation))
                throw new ArgumentException("PickupLocation is required.", nameof(booking.PickupLocation));

            if (booking.CreateDate == default)
                booking.CreateDate = DateTime.UtcNow;
            else 
                booking.CreateDate = booking.CreateDate.ToUniversalTime();

            booking.BookingDate = booking.BookingDate.ToUniversalTime();
            booking.BookingCode = "HG-" + (_repo.SelectAllAsync().Result.Count() + 10001);

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
            if (string.IsNullOrWhiteSpace(booking.PickupLocation))
                throw new ArgumentException("PickupLocation is required.", nameof(booking.PickupLocation));

            // preserve original CreateDate
            var existing = await _repo.SelectByIdAsync(booking.Id);
            if (existing == null) throw new InvalidOperationException("Booking not found.");
            booking.BookingCode = "HX-" + (_repo.SelectAllAsync().Result.Count() + 10001);

            booking.CreateDate = existing.CreateDate;

            await _repo.UpdateAsync(booking);
        }

        public async Task<IEnumerable<BusRoute>> GetAllBusRouteAsync()
        {
            return await _repo.GetAllBusRouteAsync();
        }

        public async Task<IEnumerable<ShowBusBookingDTO?>> GetBusBookingDetailsAsync(Guid id)
        {
            var bookings = await _repo.SelectBookByAsync(id);
            var schedules = await _shedul.SelectAllAsync();
            var routes = await _repo.GetAllBusRouteAsync();

            var data = from booking in bookings
                       join schedule in schedules
                       on booking.BusRouteId equals schedule.RootId into scheduleGroup
                       join route in routes
                       on booking.BusRouteId equals route.Id into routeGroup // 'route' scope ends here
                       from subSchedule in scheduleGroup.DefaultIfEmpty()
                       from subRoute in routeGroup.DefaultIfEmpty()
                       select new ShowBusBookingDTO
                       {
                           Id = booking.Id,
                           Bus = subSchedule?.BusNo,
                           BookingId = booking.BookingCode,
                           StartTime = booking.BookingDate.ToLocalTime(),
                           Seats = booking.NoOfSeats,
                           Route = subRoute?.RouteNo,
                           PickupLocation = booking.PickupLocation
                       };

            return data.ToList(); // Recommended to materialize the query
        }


    }
}