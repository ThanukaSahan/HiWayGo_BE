namespace HiwayGo_API.Entity
{
    public class UserRole
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
