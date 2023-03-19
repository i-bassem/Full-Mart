using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using FullMart.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]

public class OrderController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }



    [HttpGet("{username}")]
    public async Task<ActionResult<IReadOnlyList<OrderDTO>>> GetOrdersByUsernameAsync(string username)
    {
        if (username == null)
        {
            throw new ArgumentNullException("username");
        }
        var orders = await unitOfWork.Orders.GetOrdersByUsernameAsync(username);

        var orderDTOs = mapper.Map<IReadOnlyList<OrderDTO>>(orders);

        return Ok(orderDTOs);
    }
   
 
    [HttpPost("{userId}")]
    public async Task<ActionResult<OrderDTO>> CreateOrderAsync(string userId, [FromBody] OrderCreateDTO orderDTO)
    {
        // Create the order
        var order = await unitOfWork.Orders.CreateOrderAsync(userId, mapper.Map<List<OrderProduct>>(orderDTO.OrderProducts));

        // Map the order to an OrderDTO
        var orderDTOs = mapper.Map<OrderDTO>(order);

        // Return the OrderDTO in the response
        return Ok(orderDTOs);
    }


    [HttpPost("{orderId}/products/{productId}")]
    public async Task<ActionResult<OrderDTO>> AddProductToOrder(int orderId, int productId)
    {
        // Call the AddProductToOrderAsync method in the repository to add the product to the order
        var order = await unitOfWork.Orders.AddProductToOrderAsync(orderId, productId);

        return Ok(order);
    }

    [HttpDelete("orders/{orderId}/products/{productId}")]
    public async Task<ActionResult<OrderDTO>> DeleteProductFromOrder(int orderId, int productId)
    {
        try
        {
            // Call the DeleteProductFromOrderAsync method in the repository to remove the product from the order
            var order = await unitOfWork.Orders.DeleteProductFromOrderAsync(orderId, productId);

            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
 









}
