using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }


        public int ProductId { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
