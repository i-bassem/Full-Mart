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
    public class CategoriesRepo : BaseRepositiory<Category>, ICategoriesRepo
    {
        private readonly ApplicationDbContext _context;
        public CategoriesRepo(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public int Count()
        {
            return _context.Categories.Count();
        }

        public async Task<Category> GetByName(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == name);
            //.Include("Products")


            return category;
        }
    }
}
