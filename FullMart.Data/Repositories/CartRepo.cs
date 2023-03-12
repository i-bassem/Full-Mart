using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Data.Repositories
{

    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext context;

        public CartRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Cart> AddCart(string userId)
        {
            
            AppUser user = await context.AppUsers.FindAsync(userId);
            
            Cart cart=new Cart() { AppUser=user };
            await context.Carts.AddAsync(cart);
            return  cart;
        }

        public async Task<Cart> DeletCart(string userId)
        {
            Cart cart= await context.Carts.Include("AppUser").FirstOrDefaultAsync(a=>a.AppUser.Id==userId);
             context.Carts.Remove(cart);
            return cart;
        }
    }
}
