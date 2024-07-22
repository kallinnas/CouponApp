using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CouponApp.Model;

namespace CouponSystem.Models
{
    [Table("coupons")]
    public class Coupon
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public long Id { get; set; }
        [ForeignKey("company_id")] public virtual Company? Company { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public virtual ICollection<CustomerCoupon> CustomerCoupons { get; set; } = new List<CustomerCoupon>();

        public Coupon() { }

        public bool SimilarCoupon(Coupon coupon)
        {
            return Title == coupon.Title &&
                   Category == coupon.Category &&
                   Price == coupon.Price &&
                   Description == coupon.Description &&
                   ImageURL == coupon.ImageURL;
        }
    }
}
