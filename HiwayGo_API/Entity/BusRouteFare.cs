using System.ComponentModel.DataAnnotations.Schema;

namespace HiwayGo_API.Entity
{
    public class BusRouteFare
    {
        public Guid Id { get; set; }
        public Guid BusRouteId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal FareAmount { get; set; }

        public DateTime ActiveDate  { get; set; } = DateTime.Now;

        public BusRoute BusRoute { get; set; }
    }
}
