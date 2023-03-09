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
            throw new NotImplementedException();
        }

        public void DeleteProductFromUserCart(string userId, int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<WishList>> GetProductByUserIdAsync(string UserName)
        {
            return await _context.Set<WishList>()
                .Include(a => a.AppUser)
                .Include(wp => wp.WishListProducts)
                .ThenInclude(wp => wp.Product)
                .Where(p => p.AppUser.UserName == UserName)
                .ToListAsync();
        }
    }
}
