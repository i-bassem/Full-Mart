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
    internal class CartProductsRepo : ICartProductsRepo
    {
        private readonly ApplicationDbContext context;

        public CartProductsRepo(ApplicationDbContext context) 
        {
            this.context = context;
        }
        
         public void AddProductToUserCart(string userId, int productId)
         {
             var cart = context.Carts.Include("AppUser").FirstOrDefault(a => a.AppUser.Id == userId);
             int cartId = cart.Id;
             CartProduct cartProduct=new CartProduct() { CartId=cartId,ProductId=productId};
             context.CartProducts.Add(cartProduct);

         }

         public void DeleteProductFromUserCart(string userId, int productId)
         {
             var cart = context.Carts.Include("AppUser").FirstOrDefault(a => a.AppUser.Id == userId);
             int cartId = cart.Id;
             CartProduct? cartProduct = context.CartProducts.Find(cartId,productId);
             if(cartProduct != null) context.CartProducts.Remove(cartProduct);

         }

         public IEnumerable<Product> GetProductsByUserId(string userId)
         {
             var cart=context.Carts.Include("AppUser").FirstOrDefault(a=>a.AppUser.Id==userId);
             int? cartId = cart.Id;
             return context.CartProducts.Include("Product").Where(a=>a.CartId==cartId).Select(a=>a.Product).ToList();


         }
        


    }
}
