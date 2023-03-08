using AutoMapper;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_unitOfWork.Categories.GetAll());
        }

        [HttpGet("{id}")]
        public  IActionResult GetById(int id)
        {
            return Ok( _unitOfWork.Categories.GetById(c => c.Id == id));
                 
        }


    }
}
