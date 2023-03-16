using FullMart.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Interfaces
{
    public interface ICartRepo { 
       
       Task<Cart> AddCart(string userId);

       Task<Cart> DeletCart(string userId);

    }
}
