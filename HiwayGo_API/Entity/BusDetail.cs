namespace HiwayGo_API.Entity
{
    public class BusDetail
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid BusModelId { get; set; }
        public int NoSheets { get; set; }
        public int AllowBooking { get; set; }
        public int Type { get; set; }
    }
}
