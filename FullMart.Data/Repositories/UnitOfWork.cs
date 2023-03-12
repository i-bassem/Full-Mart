using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using FullMart.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace FullMart.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext _context;


        //Prop


        //public IBaseRepo<Product> Products { get;  }

        public IProductRepo Products { get; }
        public ICartProductsRepo CartProducts { get; }
        public ICartRepo Carts { get; }

        public IBaseRepo<Review> Reviews {get;}

        public IBaseRepo<Order> Orders { get; }

        public IBaseRepo<Brand> Brands { get; }


        public IBaseRepo<WishListProduct> WishListProducts { get; }
        public IWishListProductRepo wishListProductRepo { get; }

        public IBaseRepo<Category> Categories { get; }

        public IBaseRepo<WishList> WishLists => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Products = new ProductRepo(_context);
            CartProducts= new CartProductsRepo(_context);

            Categories = new BaseRepositiory<Category>(_context);

            WishListProducts = new BaseRepositiory<WishListProduct>(_context);
            wishListProductRepo = new WishListProductRepo(_context);

            Carts = new CartRepo(_context);

            Brands = new BaseRepositiory<Brand>(_context);

            Reviews = new BaseRepositiory<Review>(_context);

            Orders = new BaseRepositiory<Order>(_context);
            
        }

      

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
