﻿using FullMart.Core.Interfaces;
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


      
        public IProductRepo Products { get; }


      

        public IBaseRepo<Order> Orders { get; }

        public IBaseRepo<Brand> Brands { get; }

        public IBaseRepo<Cart> Carts { get; }

        public IBaseRepo<WishListProduct> WishListProducts { get; }
        public IWishListProductRepo wishListProductRepo { get; }

        public IBaseRepo<Category> Categories { get; }

        public IBaseRepo<WishList> WishLists => throw new NotImplementedException();

        public IReviewRepo Reviews { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Products = new ProductRepo(_context);

            Categories = new BaseRepositiory<Category>(_context);

            WishListProducts = new BaseRepositiory<WishListProduct>(_context);
            wishListProductRepo = new WishListProductRepo(_context);

            Carts = new BaseRepositiory<Cart>(_context);

            Brands = new BaseRepositiory<Brand>(_context);

           

            Orders = new BaseRepositiory<Order>(_context);

            Reviews = new ReviewRepo(_context); 
            
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
