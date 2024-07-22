using CouponApp.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponSystem.Models
{
    public class Customer : Client
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public virtual ICollection<CustomerCoupon> CustomerCoupons { get; set; } = new List<CustomerCoupon>();

        public Customer() { Role = 1; }

        public void BuyCoupon(Coupon coupon)
        {
            CustomerCoupons.Add(new CustomerCoupon { Coupon = coupon, Customer = this });
        }


        //public Customer(long id)
        //{
        //Role = 1;
        //Id = id;
        ////Coupons = new List<Coupon>();
        //}

        //public static Customer Empty() { return new Customer(NO_ID); }
    }
}
