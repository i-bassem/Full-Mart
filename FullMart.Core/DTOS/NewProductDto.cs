using FullMart.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class NewProductDto
    {

        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string PName { get; set; }

        [Required, MaxLength(250)]
        public string PDescription { get; set; }

        public decimal Price { get; set; }

        public byte Rate { get; set; }

        public int Quantity { get; set; }


        [Required]
        public IFormFile ImageUrl { get; set; } //[IFormFile => Name Of File , Size Of File , Kind Of File]

        public List<Category>? Categories { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}
