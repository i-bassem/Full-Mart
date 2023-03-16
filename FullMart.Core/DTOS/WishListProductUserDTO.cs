﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class WishListProductUserDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public byte Rate { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

    }
}
