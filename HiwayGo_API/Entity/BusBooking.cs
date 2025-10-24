using System.ComponentModel.DataAnnotations.Schema;

namespace HiwayGo_API.Entity
{
    public class BusBooking
    {
        public Guid Id { get; set; }
        public Guid BusRouteId { get; set; }
        public Guid BusId { get; set; }
        public Guid BookBy { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PayAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsTransactionComplete { get; set; }

    }
}
