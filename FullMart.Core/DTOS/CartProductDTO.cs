using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class CartProductDTO
    {
        public int Id { get; set; }
        public string PName { get; set; }

        public string PDescription { get; set; }

        public decimal Price { get; set; }

        public byte Rate { get; set; }




    }
}
