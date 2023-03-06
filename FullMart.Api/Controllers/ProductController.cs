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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            var products = await _unitOfWork.Products.GetAll(new[] { "Category","Brand", });

            //var result = products.Select(p => new ProductCategoryBrandDto
            //{
            //    Id = p.Id,
            //    ProductName = p.PName,
            //    Price = p.Price,
            //    Quantity = p.Quantity,
            //    BrandName = p.Brand.BrandName,
            //    CategoryName = p.Category.CategoryName
            //});
           



            var result = _mapper.Map<IEnumerable<ProductCategoryBrandDto>>(products);


            return Ok(result);

        }
    }
}
