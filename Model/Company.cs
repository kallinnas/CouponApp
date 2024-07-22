using System.ComponentModel.DataAnnotations.Schema;

namespace CouponSystem.Models
{
    public class Company : Client
    {
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();

        public Company() { Role = 2; }

        public void CreateCoupon(Coupon coupon)
        {
            coupon.Company = this;
            Coupons.Add(coupon);
        }

        //public Company(long id)
        //{
        //    Role = 2;
        //    Id = id;
        //    //Coupons = new List<Coupon>();
        //}

        //public static Company Empty() { return new Company(NO_ID); }

    }
}
