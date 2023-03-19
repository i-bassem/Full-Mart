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

      

       
        public string PName { get; set; }

       
        public string PDescription { get; set; }

        public decimal Price { get; set; }

        public byte Rate { get; set; }

        public int Quantity { get; set; }


      
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    
        public int BrandId { get; set; }

    }
}
