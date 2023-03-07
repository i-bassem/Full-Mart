using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
       Task<T> GetById(Expression<Func<T, bool>> expression, string[] includes = null);


        Task<IEnumerable<T>> GetAll(string[] includes = null);

        void Create (T entity);

        void Update(T entity);
        
        void Delete(T entity);


    }
}
