using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Interfaces
{
    public interface IProductRepo: IBaseRepo<Product>
    {
        int Count();

        Task <IEnumerable<Product>> GetByCategory(string categoryName);
        Task <IEnumerable<Product>> GetProductByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetByBrand(string brandName);

        Task<IEnumerable<Product>> GetByName(string name);
        Task<IEnumerable<Product>> GetProductsByRating(int rate);
    }
}
