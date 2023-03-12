using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class NewReviewDto
    {


        public string Comment { get; set; }

        public byte NumberOfStar { get; set; }

        public int ProductId { get; set; }
    
        public string AppUserId { get; set; }
    }
}

