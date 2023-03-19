using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace FullMart.Data.Repositories
{
    public class WishListProductRepo : BaseRepositiory<WishListProduct>, IWishListProductRepo
    {
        private readonly ApplicationDbContext _context;
        public WishListProductRepo(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        public void AddProductToUserWishList(string userId, int ProductId)
        {
            var list = _context.WishLists.Include("AppUser").SingleOrDefault(w => w.AppUser.Id == userId);
            try
            {


                if (list is not null)
                {
                    int UserList = list.Id;
                    WishListProduct WishList = new WishListProduct()
                    {
                        WishlistId = UserList,
                        ProductId = ProductId
                    };
                    _context.WishListProducts.Add(WishList);
                }
            }
            catch (Exception ex)
            {
                object[] args = { ex };
            }
        }

        public void DeleteProductFromUserCartAsync(string userId, int productId)
        {
            var list = _context.WishLists.Include("AppUser").FirstOrDefault(w => w.AppUser.Id == userId);
            if (list is not null)
            {
                int UserList = list.Id;

                WishListProduct? product = _context.WishListProducts.Include("Product")
                    .Where(w =>w.WishlistId == UserList && w.ProductId == productId).SingleOrDefault();
                if (product is not null)
                {
                    _context.WishListProducts.Remove(product);
                }
            }
            throw new NotImplementedException();
           
        }

        public async Task<IEnumerable<Product>> GetProductByUserIdAsync(string UserId)
        {
            var wishlist = _context.WishLists.Include("AppUser")
                .SingleOrDefault(u => u.AppUser.Id == UserId);
            int wishListId = 0;
            if(wishlist is not null)
            {
                wishListId = wishlist.Id;

            }
            return await _context.WishListProducts.Include("Product")
                        .Where(w => w.WishlistId == wishListId)
                        .Select(p => p.Product).ToListAsync();
            
        }

        public async Task<int> GetProductCount(string UserId)
        {
            var wishlist = _context.WishLists.Include("AppUser")
                .SingleOrDefault(u => u.AppUser.Id == UserId);

            int wishListId = 0;
            if (wishlist is not null)
                wishListId = wishlist.Id;
            return  _context.WishListProducts.Include("Product")
                    .Where(w => w.WishlistId == wishListId)
                    .Count();
        }
    }
}
