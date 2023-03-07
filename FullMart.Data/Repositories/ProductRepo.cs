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
    internal class ProductRepo:BaseRepositiory<Product>,IProductRepo
    {
        private readonly ApplicationDbContext context;

        public ProductRepo(ApplicationDbContext context):base(context)
        { 
           this.context = context;
        }

        public int Count()
        {
            return context.Products.Count();
        }

        public async Task<Product> GetByBrand(string brandName)
        {
            var product = await context.Products
               .Include("Category")
               .Include("Brand")
               .FirstOrDefaultAsync(p => p.Brand.BrandName == brandName);

            return product;
        }

        public async Task<Product> GetByCategory(string categoryName)
        {
            var product = await context.Products
               .Include("Category")
               .Include("Brand")
               .FirstOrDefaultAsync(p => p.Category.CategoryName == categoryName);

            return product;

        }

        public async Task<Product> GetByName(string name)
        {

            var product = await  context.Products
                .Include("Category")
                .Include("Brand")
                .FirstOrDefaultAsync(p => p.PName == name);

            return product;
        }
    }




     
}
