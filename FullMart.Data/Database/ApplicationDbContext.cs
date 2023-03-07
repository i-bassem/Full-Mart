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

        }


       
    }
}
