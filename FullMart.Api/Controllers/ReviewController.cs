using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corspolicy")]
    public class ReviewController : ControllerBase
    {


        #region  Properites
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public ReviewController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion


        #region Actions


        //https://localhost:7191/api/Review/GetReviewByProductId?productId=44

        [HttpGet("GetReviewByProductId")]

        public async Task<IActionResult> GetReview(int productId)
        {
            try
            {
                var review = await _unitOfWork.Reviews.GetReviewByProductId(productId);
                if (review == null)
                {
                    return NotFound();
                }
                var result = _mapper.Map <ReviewProductDto>(review);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }






        }



        //https://localhost:7191/api/Review/DeleteReview?id=22
        [HttpDelete ("DeleteReview")]

        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                var review = await _unitOfWork.Reviews.GetById(r => r.Id == id);

                if (review != null)
                {
                    _unitOfWork.Reviews.Delete(review);
                    _unitOfWork.Complete();
                }
                return NoContent();
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
            
           
        }


        //https://localhost:7191/api/Review/CreatReview

        [HttpPost("CreatReview")]
        public async Task<IActionResult> AddReview([FromForm] NewReviewDto dto)
        {
            try
            {
                var result = _mapper.Map<Review>(dto);

                _unitOfWork.Reviews.Create(result);

                _unitOfWork.Complete();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        #endregion


    }
}
