using AutoMapper;
using FullMart.Core.DTOS;
using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetBrands()
        {
            var brands = await _unitOfWork.Brands.GetAll(new string[] { "Products" });
            var brandDTOs = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandDTO>>(brands);
            return Ok(brandDTOs);
        }
        // GET: api/brands/5
        [HttpGet("GetbybrandName")]
        public async Task<ActionResult<BrandDTO>> GetByNmae(string Name)
        {
            var brand = await _unitOfWork.Brands.GetById(p => p.BrandName == Name, includes: new string[] { "Products" });

            if (brand == null)
            {
                return NotFound();
            }

            var brandDto = _mapper.Map<BrandDTO>(brand);

            return Ok(brand);
        }
        //// GET: api/brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> GetBrandById(int id)
        {
           
            var brand = await _unitOfWork.Brands.GetById(p => p.Id == id, includes: new string[] {  "Products" });

            if (brand == null)
            {
                return NotFound();
            }

            var brandDto = _mapper.Map<BrandDTO>(brand);

            return Ok(brandDto);
        }


        // PUT: api/brands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] BrandDTO brandDto)
        {
            if (id != brandDto.Id)
            {
                return BadRequest();
            }

            var brand = await _unitOfWork.Brands.GetById(p => p.Id == id);

            if (brand == null)
            {
                return NotFound();
            }

            brand.BrandName = brandDto.BrandName;
            _unitOfWork.Brands.Update(brand);

            try
            {
                _unitOfWork.Complete();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        // POST: api/brands
        [HttpPost]
        public IActionResult CreateBrand([FromBody] BrandDTO brandDTO)
        {
            if (brandDTO == null)
            {
                return BadRequest();
            }
            var brand = _mapper.Map<Brand>(brandDTO);
            _unitOfWork.Brands.Create(brand);
            _unitOfWork.Complete();
            var createdBrandDTO = _mapper.Map<BrandDTO>(brand);
            return CreatedAtAction(nameof(GetBrandById), new { id = createdBrandDTO.Id }, createdBrandDTO);
        }


    }
}

