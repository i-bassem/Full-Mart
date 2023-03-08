using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class CartProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public ICollection<Product>? Products { get; set; } = new HashSet<Product>();

        public int CartId { get; set; }

        public ICollection<Cart>? Carts { get; set; } = new HashSet<Cart>();

    }
}
