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
            var category = await _context.Categories
                          .Include("Products")
                          .FirstOrDefaultAsync(c => c.CategoryName == name);

            return category;
        }

        public async Task<Category> GetById(Expression<Func<Category, bool>> expression, string[] includes = null)
        {
            IQueryable<Category> query = _context.Set<Category>();

            if (includes != null)

                foreach (var includeValue in includes)
                    query = query.Include(includeValue);

            return await query.FirstOrDefaultAsync(expression);
        }
    }
}
