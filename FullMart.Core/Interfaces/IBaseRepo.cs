using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
       Task<T> GetById(int id);


        Task<IEnumerable<T>> GetAll(string[] includes = null);

        void Create (T entity);

        void Update(T entity);
        
        void Delete(T entity);


    }
}
