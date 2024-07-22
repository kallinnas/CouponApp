using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponSystem.Models
{
    [Table("users")]
    public class User
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public long Id { get; set; }
        [Required][EmailAddress] public string Email { get; set; } = string.Empty;
        [Required][PasswordPropertyText] public string Password { get; set; } = string.Empty;
        public virtual Client? Client { get; set; }
        [Column("client_id")] public long? ClientId { get; set; }
        public User() { }
        public User(string email, string password, int role)
        {
            Email = email;
            Password = password;

            if (role == 1) { Client = new Customer(); }
            else { Client = new Company(); }
        }
    }
}
