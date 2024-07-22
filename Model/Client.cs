using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponSystem.Models
{
    [Table("clients")]
    public abstract class Client
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public long Id { get; set; }
        public virtual User? User { get; set; }
        public int Role { get; set; }
        public const int NO_ID = -1;
    }
}
