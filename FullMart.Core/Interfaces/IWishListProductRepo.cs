using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullMart.Core.Models;

namespace FullMart.Core.Interfaces
{
    public interface IWishListProductRepo : IBaseRepo<WishListProduct>
    {
        public  Task<IEnumerable<Product>> GetProductByUserIdAsync(string UserId);
        public void AddProductToUserWishList(string userId, int ProductId);
        public void DeleteProductFromUserCartAsync(string userId, int productId);
        public Task<int> GetProductCount(string UserId);
        public WishList CreateWishlist(string UserId);
        
    }
}
