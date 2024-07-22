using Microsoft.EntityFrameworkCore;
using CouponSystem.Models;
using CouponApp.Model;

namespace CouponSystem.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CustomerCoupon> CustomerCoupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // redundant because of [Table("users")] and [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] annotations
            //modelBuilder.Entity<User>().ToTable("users").HasKey(u => u.Id);
            modelBuilder.Entity<Customer>().ToTable("customers").HasBaseType<Client>();
            modelBuilder.Entity<Company>().ToTable("companies").HasBaseType<Client>();

            modelBuilder.Entity<User>().HasOne(u => u.Client).WithOne(c => c.User)
                .HasForeignKey<User>(u => u.ClientId).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CustomerCoupon>().ToTable("customer_coupon")
                .HasKey(cc => new { cc.CouponId, cc.CustomerId });
            modelBuilder.Entity<CustomerCoupon>()
                .HasOne(cc => cc.Coupon)
                .WithMany(c => c.CustomerCoupons)
                .HasForeignKey(cc => cc.CouponId);
            modelBuilder.Entity<CustomerCoupon>()
                .HasOne(cc => cc.Customer)
                .WithMany(c => c.CustomerCoupons)
                .HasForeignKey(cc => cc.CustomerId);

        }

    }
}