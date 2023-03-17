using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using FullMart.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullMart.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WishListController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        

        //https://localhost:7191/api/WishList/GetProductByUserID?id=1
        [HttpGet("GetProductByUserID")]
        public async Task<IActionResult> GetProductByUserID(string UserId)
        {
            var product = await _unitOfWork.wishListProductRepo.GetProductByUserIdAsync(UserId);
            if(product == null)
            {
                return BadRequest("The Product Is Not Exist");
            }
            //return Ok(product);
            return Ok(_mapper.Map<IEnumerable<WishListProductUserDTO>>(product));
        }


        //https://localhost:7191/api/WishList/GetProductCount
        [HttpGet("GetProductCount")]
        public async Task<int> GetProductCount(string UserId)
        {
            return await _unitOfWork.wishListProductRepo.GetProductCount(UserId);
        }


        //https://localhost:7191/api/WishList/AddProductToWishlist
        [HttpPost("AddProductToWishlist")]
        public async Task<IActionResult> AddProductToWishlist(string UserId , int ProductId)
        {
            try
            {
                if (UserId == null || ProductId == 0)
                {
                    return NotFound($"The Product with ID : {ProductId} Or " +
                    $"User With ID  : {UserId} IS NOT VALID");
                }

                _unitOfWork.wishListProductRepo.AddProductToUserWishList(UserId, ProductId);
                _unitOfWork.Complete();

                return Ok($"Product with ID {ProductId} added to wishlist for user with ID {UserId}.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding product with ID : ( {ProductId} )" +
                    $" to wishlist for user with ID : ( {UserId} ) : {ex.Message}");
            }
        }


        //https://localhost:7191/api/WishList/DeleteByProductId
        [HttpDelete("DeleteByProductId")]
        public async Task<IActionResult> DeleteByProductId(string UserId , int ProductId)
        {
            try
            {
                _unitOfWork.wishListProductRepo.DeleteProductFromUserCartAsync(UserId, ProductId);

                _unitOfWork.Complete();
                return Ok($"The product with ID : ( {ProductId} ) " +
                    $"at user's wishList with ID : {UserId} Is Deleted Successfully.");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting product with ID {ProductId}" +
                    $" from wishlist for user with ID {UserId}: {ex.Message}");
            }
        }

    }
}