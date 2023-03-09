using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Interfaces
{
    public interface ICartProductsRepo
    {
        public IEnumerable<Product> GetProductsByUserId(string userId);
        public void AddProductToUserCart(string userId,int productId);
        public void DeleteProductFromUserCart(string userId, int productId);
    }
}
