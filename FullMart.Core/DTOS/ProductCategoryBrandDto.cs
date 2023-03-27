using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class ProductCategoryBrandDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public byte Rate { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }
        public string BrandName { get; set; }

        public List<ProductReview>? Reviews { get; set; } = new List<ProductReview>();

        public bool? IsFree { get; set; }
    }




    public class ProductReview
    {
        public int ReviewID { get; set; }
        public string ReviewComment { get; set; }

        public int NumberOfStars { get; set; }


    }
}
