namespace HiwayGo_API.Entity
{
    public class BusRoute
    {
        public Guid Id { get; set; }
        public string RouteNo { get; set; }
        public string City1 { get; set; }
        public string City2 { get; set; }

        public ICollection<BusRouteFare> BusRouteFare { get; set; }
        public ICollection<BusBooking> BusBooking { get; set; }
    }
}
