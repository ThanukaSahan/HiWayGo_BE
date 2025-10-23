using System.ComponentModel.DataAnnotations;

namespace HiwayGo_API.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string NIC { get; set; } //user name
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        [Phone]
        public int PhoneNumber { get; set; }

        [Required]
        public Guid UserRoleId { get; set; }
        public bool IsOwner { get; set; }        
        public bool IsActive { get; set; }
        public UserRole UserRole { get; set; }
    }
}
