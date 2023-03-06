using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {

        IProductRepo  Products { get; }

        IBaseRepo<Review> Reviews { get; }
        IBaseRepo<Order> Orders { get; }
        IBaseRepo<Brand> Brands { get; }
        IBaseRepo<Cart> Carts { get; }
        IBaseRepo<WishList> WishLists { get; }
        IBaseRepo<Category> Categories { get; }
        int Complete(); //Return Number Of Effected Rows [SaveChanges]
    }
}
