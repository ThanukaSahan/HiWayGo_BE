using System;

namespace HiwayGo_API.DTO
{
    public class ShowBusBookingDTO
    {
        public Guid Id { get; set; }
        public string Bus { get; set; }
        public String BookingId { get; set; }
        public DateTime StartTime { get; set; }
        public int Seats { get; set; }
        public String Route { get; set; }
        public string PickupLocation { get; set; }
    }
}
