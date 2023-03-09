using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;


namespace FullMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<string> _allowedExtensions = new() { ".jpg", ".png" };

        private long _maxAllowedImageSize = 1048576;


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IUnitOfWork unitOfWork , IMapper mapper 
            ,IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;  
            _environment = environment;
        }


        //https://localhost:7191/api/Product/GetAllProduct

        [HttpGet("GetAllProduct")]
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



        //https://localhost:7191/api/Product/5

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



        //https://localhost:7191/api/Product/GetProductByName?name=
        [HttpGet("GetProductByName")]

        public async  Task<IActionResult> GetProductByName(string name)
        {

            var product = await _unitOfWork.Products
                .GetByName(name);

            if (product == null)
            {
                return BadRequest($"The Product With this Id = {name} Not Found..");
            }

            var result = _mapper.Map<ProductCategoryBrandDto>(product);

            return Ok(result);
        }

        [HttpGet("GetProductByCategoryName")]


        //https://localhost:7191/api/Product/GetProductByCategoryName?name=Electronics
        public async Task<IActionResult> GetProductByCategory(string name)
        {

            var product = await _unitOfWork.Products
                .GetByCategory(name);

            if (product == null)
            {
                return BadRequest($"The Product With Category Name = {name} Not Found..");
            }

            var result = _mapper.Map<ProductCategoryBrandDto>(product);

            return Ok(result);
        }



        //https://localhost:7191/api/Product/GetProductByBrandName?name=Adidas
        [HttpGet("GetProductByBrandName")]

        public async Task<IActionResult> GetProductByBrand(string name)
        {

          
           
            var product = await _unitOfWork.Products
                .GetByBrand(name);

            if (product == null)
            {
                return BadRequest($"The Product With this Brand Name = {name} Not Found..");
            }

            var result = _mapper.Map<ProductCategoryBrandDto>(product);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] NewProductDto dto)
        {
           

            if (dto.ImageUrl == null)
            {
                return BadRequest("Image Is Required");
            }

            if (!_allowedExtensions.Contains(Path.GetExtension(dto.ImageUrl.FileName).ToLower()))
            {
                return BadRequest("Only .jpg and .png  images  are allowed");
            }

            if (dto.ImageUrl.Length > _maxAllowedImageSize)
            {
                return BadRequest("Max allowed Image Size is 1MB");
            }

            using var stream = new MemoryStream();

            await dto.ImageUrl.CopyToAsync(stream);
            StreamReader reader = new(stream);
            string text = reader.ReadToEnd();



            var product = _mapper.Map<Product>(dto);
            product.ImageUrl = text.ToString();

            

            _unitOfWork.Products.Create(product);

            _unitOfWork.Complete();

            return Ok();

        }



        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct(int id, [FromForm] NewProductDto dto)
        {

            try
            {
                var product = await _unitOfWork.Products.GetById(p => p.Id == id);

                if (product == null)
                    return NotFound($" No Product was found with this Id {id}");

                string text = "";

                if (dto.ImageUrl != null)
                {
                    if (!_allowedExtensions.Contains(Path.GetExtension(dto.ImageUrl.FileName).ToLower()))
                    {
                        return BadRequest("Only .jpg and .png  images  are allowed");

                    }
                    if (dto.ImageUrl.Length > _maxAllowedImageSize)
                    {
                        return BadRequest("Max allowed Image Size is 1MB");
                    }

                    var dataStream = new MemoryStream();
                    await dto.ImageUrl.CopyToAsync(dataStream);

                    StreamReader reader = new(dataStream);
                    text = reader.ReadToEnd();
                    product.ImageUrl = text.ToString();

                }

                var result = _mapper.Map<Product>(dto);
              


                _unitOfWork.Products.Update(result);

                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                
                throw;
            }
          
        }





        //https://localhost:7191/api/Product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetById(p => p.Id ==id);

            if (product == null)
                return NotFound($"No Product was found with Id {id}");

            _unitOfWork.Products.Delete(product);
            _unitOfWork.Complete();

            return Ok(product);
        }


    }
}
