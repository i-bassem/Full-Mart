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

        Task<IEnumerable<Product>> GetByCategory(int categoryId);
        Task<IEnumerable<Product>> GetByBrand(int brandId);



       Task< IEnumerable<Product>> GetByName(string name);
    }
}
