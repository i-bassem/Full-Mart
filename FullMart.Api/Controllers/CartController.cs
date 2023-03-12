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
    public class CartController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async  Task<IActionResult> AddCart(string userId)
        {
            try
            {
               await  unitOfWork.Carts.AddCart(userId);
                if (unitOfWork.Complete() > 0) return Ok();
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCart(string userId)
        {
            try
            {
                await unitOfWork.Carts.DeletCart(userId);
                if(unitOfWork.Complete()>0)  return Ok();
                else return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






   
    }
}
