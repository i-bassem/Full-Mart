using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{

    // TV 
    public class Cart
    {

        public int Id { get; set; }


        //public ICollection<Product>? Products { get; set; } = new HashSet<Product>();

        public CartProduct CartProduct { get; set; }

        public AppUser AppUser { get; set; }
    }
}
