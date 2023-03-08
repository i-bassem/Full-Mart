using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class WishList
    {

        public int Id { get; set; }


        //public ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public WishListProduct? WishListProduct { get; set; }



        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
