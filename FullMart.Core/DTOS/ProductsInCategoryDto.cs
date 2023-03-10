using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class ProductsInCategoryDto
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string categoryImageURL { get; set; }


        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();

        public class ProductDTO 
        { 

        public int productID { get; set; }
        public string productName { get; set; }

        public decimal productPrice { get; set; }
        public int productRating { get; set; }
        public string productImageURL { get; set; }

        }

    }
}
