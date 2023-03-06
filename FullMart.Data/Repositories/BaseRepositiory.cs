using FullMart.Core.Interfaces;
using FullMart.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Data.Repositories
{
    public class BaseRepositiory<T> : IBaseRepo<T> where T : class
    {

        protected readonly ApplicationDbContext _context;
        public BaseRepositiory(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);


        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
         
        }

        public async Task<IEnumerable<T>> GetAll(string[] includes = null)
        {

            IQueryable<T> query = _context.Set<T>();

            if (includes != null)

                foreach (var includeValue in includes)
                    query = query.Include(includeValue);

            return await query.ToListAsync();
        }

        public async Task< T> GetById(int id)
        {
            return  await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            
        }
    }
}
