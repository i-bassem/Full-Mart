using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.UnitOfWork;
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
            var lists = await _unitOfWork.WishLists.GetAll(new[] { "Product" });
            
            if (lists == null)
            {
                return Content("No DATA AVAILABLE");
            }
            var result = _mapper.Map<IEnumerable<WishListProductUserDTO>>(lists);

            return Ok(result);
        }
    }
}
