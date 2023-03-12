using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullMart.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CartProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CartProductsController(IUnitOfWork unitOfWork, IMapper mapper
            , IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult getProductByUserId(string userId)
        {
            try
            {
                var result = _mapper.Map<IEnumerable<CartProductDTO>>(_unitOfWork.CartProducts.GetProductsByUserId(userId));
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddProductToCart(string userId,int productId)
        {
            try
            {
                _unitOfWork.CartProducts.AddProductToUserCart(userId, productId);

                if (_unitOfWork.Complete() > 0) return Ok();
               else return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult DeleteProductFromCart(string userId, int productId)
        {
            try
            {
                _unitOfWork.CartProducts.DeleteProductFromUserCart(userId, productId);
                if(_unitOfWork.Complete()>0) return Ok();
                else return BadRequest();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
