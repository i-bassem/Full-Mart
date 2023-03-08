using FullMart.Core.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Data.Database
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }


        public  DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Order> Orders { get; set; }


        public DbSet<WishListProduct> WishListProducts { get; set; }
        public DbSet<BrandCategory> BrandCategories { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("Users", "Security");//.Ignore(e => e.PhoneNumberConfirmed);
            builder.Entity<IdentityRole>().ToTable("Roles", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleCliams", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Security");



            //builder.Entity<WishList>()
            //   .HasOne(a => a.AppUser)
            //   .WithOne(a => a.WishList)
            //   .HasForeignKey<AppUser>(a => a.WishListId);


            #region Many To Many realtionship between wishlist and products

            builder.Entity<WishListProduct>()
                .HasKey(wp => new { wp.WishlistId, wp.ProductId });

            builder.Entity<WishListProduct>()
                .HasOne(p => p.Product)
                .WithMany(wp => wp.WishListProducts)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<WishListProduct>()
                .HasOne(w => w.WishList)
                .WithMany(wp => wp.WishListProducts)
                .HasForeignKey(w => w.WishlistId);

            #endregion

            #region Many To Many realtionship between order and products

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<OrderProduct>()
                .HasOne(p => p.Product)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<OrderProduct>()
                .HasOne(o => o.Order)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(o => o.OrderId);

            #endregion

            #region Many To Many realtionship between cart and products

            builder.Entity<CartProduct>()
                .HasKey(cp => new {cp.CartId , cp.ProductId });

            builder.Entity<CartProduct>()
                .HasOne(p => p.Product)
                .WithMany(cp => cp.CartProducts)
                .HasForeignKey(p => p.ProductId);

            builder.Entity<CartProduct>()
                .HasOne(c => c.Cart)
                .WithMany(cp => cp.CartProducts)
                .HasForeignKey(c => c.CartId);

            #endregion

            #region Many To Many realtionship between brand and category

            builder.Entity<BrandCategory>()
                .HasKey(bc => new { bc.BrandId, bc.CategoryId });

            builder.Entity<BrandCategory>()
                .HasOne(b => b.Brand)
                .WithMany(bc => bc.BrandCategories)
                .HasForeignKey(b => b.BrandId);

            builder.Entity<BrandCategory>()
                .HasOne(c => c.Category)
                .WithMany(bc => bc.BrandCategories)
                .HasForeignKey(c => c.CategoryId);

            #endregion


        }
    }
}
