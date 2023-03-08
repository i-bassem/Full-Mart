using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class BrandCategory
    {
        public int Id { get; set; }


        public int CategoryId { get; set; }
        public virtual ICollection<Category>? Categories { get; set; } = new HashSet<Category>();


        public int BrandId { get; set; }
        public virtual ICollection<Brand>? Brands { get; set; } = new HashSet<Brand>();
    }
}
