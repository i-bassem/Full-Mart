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
        public virtual ICollection<WishList>? WishLists { get; set; }


        public int ProductId { get; set; }

        public ICollection<Product>? Products { get; set; } = new HashSet<Product>();
    }
}
