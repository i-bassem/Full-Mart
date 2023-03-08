using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class WishListProduct
    {
        public int Id { get; set; }
        public int WishlistId { get; set; }
        public WishList WishList { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
