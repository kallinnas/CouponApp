using CouponSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponApp.Model
{
    public class CustomerCoupon
    {
        [Column("coupon_id")]
        public long CouponId { get; set; }
        public Coupon Coupon { get; set; } = null!;
        [Column("customer_id")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
