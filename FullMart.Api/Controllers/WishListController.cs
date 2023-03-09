using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using FullMart.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullMart.Api.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lists = await _unitOfWork.WishListProducts.GetAll(new[] { "Product" });
            
            if (lists == null)
            {
                return Content("No DATA AVAILABLE");
            }
            return Ok(_mapper.Map<IEnumerable<WishListProductUserDTO>>(lists));
        }

        //https://localhost:7191/api/WishList/GetProductByUserID?id=1
        [HttpGet("GetProductByUserName")]
        public async Task<IActionResult> GetProductByUserID(string UserName)
        {
            //var product = await _unitOfWork.WishListProducts.GetById(p => p.Product.i == id , new[] { "Product" });
            var product = await _unitOfWork.wishListProductRepo.GetProductByUserIdAsync(UserName);
            if(product == null)
            {
                return BadRequest("The Product Is Not Exist");
            }
            return Ok(_mapper.Map<IEnumerable<WishListProductRepo>>(product));
        }

        //https://localhost:7191/api/WishList/DeleteByProductId?id=1
        [HttpDelete("DeleteByProductId")]
        public async Task<IActionResult> DeleteByProductId(int id)
        {
            var product = await _unitOfWork.WishListProducts.GetById(p => p.Id == id, new[] { "Product" });
            if (product == null)
            {
                return BadRequest("This Product Is Not Exist");
            }
            _unitOfWork.WishListProducts.Delete(product);
            _unitOfWork.Complete();
            return Ok(product);
        }
    }
}