using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class NewCategoryDto
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
         
}
