using System.ComponentModel.DataAnnotations.Schema;

namespace HiwayGo_API.Entity
{
    public class BusBooking
    {
        public Guid Id { get; set; }
        public Guid BusRouteId { get; set; }
        public Nullable<Guid> BusId { get; set; }
        public Guid BookBy { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PayAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsTransactionComplete { get; set; }
        public string PickupLocation { get; set; }
        public int NoOfSeats { get; set; }

        public string BookingCode { get; set; } =String.Empty;

    }
}
