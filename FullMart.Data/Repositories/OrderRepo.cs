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
    public class OrderRepo : BaseRepositiory<Order>, IorderRepo
    {
        public OrderRepo(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<Order> CreateOrderAsync(string userId, List<OrderProduct> orderProducts)
        {
            // Retrieve the user by ID
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            // Create a new order object
            var order = new Order
            {
                AppUser = user,
                // Set any other necessary properties of the order
            };

            // Add the order to the order repository or context
            _context.Orders.Add(order);

            // Assign the order ID to each order product
            foreach (var orderProduct in orderProducts)
            {
                orderProduct.OrderId = order.Id;
            }

            // Add the order products to the order
            order.OrderProducts = orderProducts;

            await _context.SaveChangesAsync();

            return order;
        }




        //by user name 
        public async Task<IReadOnlyList<Order>> GetOrdersByUsernameAsync(string username)
        {
                 return await _context.Set<Order>()
                .Include(o => o.AppUser)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Where(o => o.AppUser.Id == username)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
     
        public async Task<Order> DeleteProductFromOrderAsync(int orderId, int productId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .SingleOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} not found");
            }

            var orderProduct = order.OrderProducts.SingleOrDefault(op => op.ProductId == productId);

            if (orderProduct == null)
            {
                throw new ArgumentException($"Product with ID {productId} not found in order with ID {orderId}");
            }

            order.OrderProducts.Remove(orderProduct);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> AddProductToOrderAsync(int orderId, int productId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .SingleOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} not found");
            }

            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                throw new ArgumentException($"Product with ID {productId} not found");
            }

            order.OrderProducts.Add(new OrderProduct
            {
                Product = product,
            });

            await _context.SaveChangesAsync();

            return order;
        }

        public Task<Order> AddProductToOrderAsync(string userId, int orderId, int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> AddUserToOrderAsync(int orderId, string userId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} not found");
            }

            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found");
            }

            order.AppUser.Id = userId;

            await _context.SaveChangesAsync();

            return order;
        }



    }








}
