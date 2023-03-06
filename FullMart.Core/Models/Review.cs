using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public byte NumberOfStar { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public  AppUser AppUser { get; set; }
    }
}
