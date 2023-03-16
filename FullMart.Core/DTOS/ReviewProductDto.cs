using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class ReviewProductDto
    {

       

        public string Comment { get; set; }

        public byte NumberOfStar { get; set; }

        

        public string ProductName { get; set; }

      

        public string UserId { get; set; }
       
    }
}
