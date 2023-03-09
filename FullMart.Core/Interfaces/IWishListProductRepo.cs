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
        public Task<IReadOnlyList<WishList>> GetProductByUserIdAsync(string UserName);
        public void AddProductToUserWishList(string userId, int ProductId);
        public void DeleteProductFromUserCart(string userId, int productId);

    }
}
