using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _unitOfWork.Categories.GetById(c => c.Id == id);
            if(cat == null) { return NotFound($"The Product With this Id = {id} Not Found..."); }
            return Ok(cat);      
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var cat = await _unitOfWork.Categories.GetById(name);


            IQueryable<T> query = _context.Set<T>();

            if (includes != null)

                foreach (var includeValue in includes)
                    query = query.Include(includeValue);

            return await query.FirstOrDefaultAsync(expression);
        }
        public async Task<IActionResult> GetProductByName(string name)
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

    }
}
