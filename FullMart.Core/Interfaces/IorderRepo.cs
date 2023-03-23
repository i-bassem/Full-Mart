using FullMart.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Interfaces
{
    public interface IorderRepo : IBaseRepo<Order>
    {

        Task<IReadOnlyList<Order>> GetOrdersByUsernameAsync(string userId);
        Task<Order> AddProductToOrderAsync(int orderId, int productId);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> DeleteProductFromOrderAsync(int orderId, int productId);
        Task<Order> CreateOrderAsync(string userId, List<OrderProduct> orderProducts);
        public Order CreateOrder(string UserId);











    }

}

