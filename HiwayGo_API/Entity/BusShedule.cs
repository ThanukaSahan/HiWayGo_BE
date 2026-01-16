namespace HiwayGo_API.Entity
{
    public class BusShedule
    {
        public Guid Id { get; set; }
        public Guid RootId {get;set;}

        public DateTime StartDate { get; set;}
        public TimeOnly StartTime { get; set;}
        public TimeOnly EndTime { get; set; }
        public String BusNo { get; set; }
        public Guid CreateUserID { get; set; }
    }
}
