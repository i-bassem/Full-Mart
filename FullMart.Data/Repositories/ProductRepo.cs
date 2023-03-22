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

        public async Task<IEnumerable<Product>> GetByBrand(string brandName)
        {
            return await context.Products
                    .Include("Category")
                .Include("Brand")
                .Include("Reviews")
               .Where(p => p.Brand.BrandName == brandName).ToListAsync();

           
        }

        public async Task<IEnumerable<Product>> GetByCategory(string categoryName)
        {
            return await context.Products
                    .Include("Category")
                .Include("Brand")
                .Include("Reviews")
               .Where(p => p.Category.CategoryName == categoryName).ToListAsync();



        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {

            return await  context.Products
                .Include("Category")
                .Include("Brand")
                .Include("Reviews")
                .Where(p => p.PName == name).ToListAsync();

          
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId)
        {
            return await context.Products
                    .Include("Category")
                .Include("Brand")
                .Include("Reviews")
               .Where(p => p.Category.Id == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByRating(int rate)
        {
            return await context.Products
                   .Include("Category")
               .Include("Brand")
               .Include("Reviews")
              .Where(p => p.Rate == rate).ToListAsync();
        }
    }




     
}
