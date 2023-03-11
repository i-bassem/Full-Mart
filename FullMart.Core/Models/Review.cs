using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
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

        public string AppUserId { get; set; }


       

        public virtual  AppUser AppUser { get; set; }
    }
}
