using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required , MaxLength(50)]
        public string  BrandName { get; set; }



        public ICollection<Product> Products { get; set; } = new HashSet<Product>(); 
    }
}
