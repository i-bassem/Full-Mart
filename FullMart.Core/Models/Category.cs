using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class Category
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required , MaxLength(150)]
        public string CategoryName { get; set; }

        [Required]
        public string ImageUrl { get; set; }


        public virtual ICollection<BrandCategory> BrandCategories { get; set; }
        //public virtual ICollection<Brand> Brands { get; set; } = new HashSet<Brand>();

    }
}
