using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace FullMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //https://localhost:44308/api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Categories.GetAll());
        }

        //https://localhost:44308/api/Categories/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var cat = await _unitOfWork.Categories.GetById(c => c.Id == id);
        //    if(cat == null) { return NotFound($"The Product With this Id = {id} Not Found..."); }
        //    return Ok(cat);      
        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetcategoryById(int id)
        {
            var category = await _unitOfWork.Categories.GetById(p => p.Id == id, new[] { "Products" });

            if (category == null)
            {
                return BadRequest($"The Product With this Id = {id} Not Found..");
            }
            var result = _mapper.Map<IEnumerable<ProductsInCategoryDto>>(category);

            return Ok(result);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var cat = await _unitOfWork.Categories.GetByName(name);
               
            if (cat == null)
            {
                return BadRequest($"The Category Name = {name} Not Found...");
            }

            var result = _mapper.Map<IEnumerable<ProductsInCategoryDto>>(cat.Products);

            ProductsInCategoryDto pc = new ProductsInCategoryDto()
            {
                categoryID = cat.Id,
                categoryName = cat.CategoryName,
                categoryImageURL = cat.ImageUrl,
            };
            
            return Ok(cat);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(NewCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Categories.Create(category);
                    _unitOfWork.Complete();
                    return Created("URL", category);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, NewCategoryDto dto)
        {
            var cat = await _unitOfWork.Categories.GetById(c=>c.Id ==id);
            if (cat != null)
            {
                try 
                {
                    var updatedcategory = _mapper.Map<Category>(dto);
                    _unitOfWork.Categories.Update(updatedcategory);
                    _unitOfWork.Complete();
                    return NoContent();
                }
                catch(Exception ex)
                {
                   return BadRequest(ex.Message);
                }
            }
            else
                return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var cat = await _unitOfWork.Categories.GetById(c => c.Id == id);
            if(cat != null)
            {
                try
                {
                    _unitOfWork.Categories.Delete(cat);
                    _unitOfWork.Complete();
                    return Ok(cat);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
                return NotFound($"Can't find Category with that Id {id}");
        }
        


    }
}
