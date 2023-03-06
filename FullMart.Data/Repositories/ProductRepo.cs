using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Data.Repositories
{
    internal class ProductRepo:BaseRepositiory<Product>,IProductRepo
    {
        private readonly ApplicationDbContext context;

        public ProductRepo(ApplicationDbContext context):base(context)
        { 
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }




     
}
