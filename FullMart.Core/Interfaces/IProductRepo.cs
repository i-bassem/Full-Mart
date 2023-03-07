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

        Task <Product> GetByCategory(string categoryName);
        Task< Product> GetByBrand(string brandName);

        Task<Product> GetByName(string name);
    }
}
