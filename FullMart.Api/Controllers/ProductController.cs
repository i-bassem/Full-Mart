using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FullMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;   
        }


        ////https://localhost:7191/api/Product
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            
            var products = await _unitOfWork.Products
                .GetAll(new[] { "Category","Brand", });


            var result = _mapper.Map<IEnumerable<ProductCategoryBrandDto>>(products);

            if (result.Any())
            {
                return Ok(result);
            }
            else
                return Content("Product is Empty");
          
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {

            var product = await _unitOfWork.Products.GetById(p => p.Id == id , new[] { "Category", "Brand", });

            if(product == null)
            {
                return BadRequest($"The Product With this Id = {id} Not Found..");
            }
            
              var result = _mapper.Map<ProductCategoryBrandDto>(product);


            return Ok(result);


        }
    }
}
