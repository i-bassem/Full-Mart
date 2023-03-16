﻿using FullMart.Core.Models.JwtModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        public List<RefreshToken>? RefreshTokens { get; set; }

        //public int? ReviewId { get; set; }
        public ICollection<Review>? Reviews { get; set; } = new HashSet<Review>();

       
        //public WishList? WishList { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
