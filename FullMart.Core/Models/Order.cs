using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class Order
    {

        public Order()
        {
            OrderDate  = DateTime.Now;
        }
        public int Id { get; set; }


        public DateTime OrderDate { get; set; }

        [Range(1,3)]
        public Status Status { get; set; }

        public AppUser AppUser { get; set; }

        public OrderProduct? OrderProducts { get; set; }

        //public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }

    public enum Status
    {
        Shiped = 1, InProgress =2, Deliverd =3
    }

   
}
