using AutoMapper;
using FullMart.Core.DTOS;

using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace FullMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        #region Properites
       


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
     


        #endregion


        #region Ctor
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
          
           
        }
        #endregion


        #region Actions

        //https://localhost:7191/api/Product/GetAllProduct

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {

            //throw new UnauthorizedAccessException();//Attempted to perform an unauthorized operation
            var products = await _unitOfWork.Products
                .GetAll(new[] { "Category", "Brand", "Reviews" });


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
            try
            {
                var product = await _unitOfWork.Products.GetById(p => p.Id == id, new[] { "Category", "Brand","Reviews" });

                if (product == null)
                {
                    return BadRequest($"The Product With this Id = {id} Not Found..");
                }

              
                var result = _mapper.Map<ProductCategoryBrandDto>(product);
              

                return Ok(result);

            }
            catch (Exception ex)
            {


                return BadRequest(ex.Message);
            }

           
            

            



        }



        //https://localhost:7191/api/Product/CountOfProduct

        [HttpGet("CountOfProduct")]
        public async Task<IActionResult> GetCountOfProduct()
        {
            var count = _unitOfWork.Products.Count();

            return Ok(count);
        }

        //https://localhost:7191/api/Product/GetProductByName?name=
        [HttpGet("GetProductByName")]

        public async Task<IActionResult> GetProductByName(string name)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByName(name);

                if (product == null)
                {
                    return BadRequest($"The Product With this Id = {name} Not Found..");
                }

                var result = _mapper.Map<IEnumerable< ProductCategoryBrandDto>>(product);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        //https://localhost:7191/api/Product/GetProductByCategoryId?id=1
        [HttpGet("GetProductByCategoryId")]

        public async Task<IActionResult> GetProductByCategory(int id)
        {
            try
            {

                

                var product = await _unitOfWork.Products
                  .GetProductByCategoryId(id);

                if (product == null)
                {
                    return BadRequest($"The Product With Category Id = {id} Not Found..");
                }

                var result = _mapper.Map<IEnumerable<ProductCategoryBrandDto>>(product);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }




       // https://localhost:7191/api/Product/GetProductsByRating?rate=1
        [HttpGet("GetProductsByRating")]
        public async Task<IActionResult> GetProductsByRating(int rate)
        {
            try
            {
                if(rate >5 || rate <= 0)
                {
                    return BadRequest("Rate Must Be Greater Than 0 Or LessThan or Equal 5");
                }


                var product = await _unitOfWork.Products
                  .GetProductsByRating(rate);

                if (product == null)
                {
                    return BadRequest($"The Product With Rate = {rate} Not Found..");
                }

                var result = _mapper.Map<IEnumerable<ProductCategoryBrandDto>>(product);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        //https://localhost:7191/api/Product/GetProductByCategoryName?name=Electronics
        [HttpGet("GetProductByCategoryName")]
        public async Task<IActionResult> GetProductByCategory(string name)
        {
            try
            {

                var product = await _unitOfWork.Products
                  .GetByCategory(name);

                if (product == null)
                {
                    return BadRequest($"The Product With Category Name = {name} Not Found..");
                }

                var result = _mapper.Map<IEnumerable<ProductCategoryBrandDto>>(product);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        //https://localhost:7191/api/Product/GetProductByBrandName?name=Adidas
        [HttpGet("GetProductByBrandName")]

        public async Task<IActionResult> GetProductByBrand(string name)
        {


            try
            {
                var product = await _unitOfWork.Products
               .GetByBrand(name);

                if (product == null)
                {
                    return BadRequest($"The Product With this Brand Name = {name} Not Found..");
                }

                var result = _mapper.Map<IEnumerable<ProductCategoryBrandDto>>(product);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }



        //https://localhost:7191/api/Product
        [HttpPost]
        public async Task<IActionResult> AddProduct( NewProductDto dto)
        {

            try
            {
               

               


               

                var product = _mapper.Map<Product>(dto);


                

                _unitOfWork.Products.Create(product);

                _unitOfWork.Complete();

                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


        //https://localhost:7191/api/Product/18
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct(int id, NewProductDto dto)
        {
            try
            {

                
                var product = await _unitOfWork.Products.GetById(p => p.Id == id);

                if (product == null)
                    return NotFound($" No Product was found with this Id {id}");



                

                //Map(dto,product) => dto it's My Dto we can called it my Form
                // product => it's my Model 

                var result = _mapper.Map(dto, product);
                


                _unitOfWork.Products.Update(result);


                _unitOfWork.Complete();

                return NoContent(); //204
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }




        }



        //(Roles ="Admin")
        [Authorize]
        
        //https://localhost:7191/api/Product/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetById(p => p.Id == id);

                if (product == null)
                    return NotFound($"No Product was found with Id = {id}");

              


                _unitOfWork.Products.Delete(product);
                _unitOfWork.Complete();

                return NoContent(); //204
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

     
        #endregion
    }
}
