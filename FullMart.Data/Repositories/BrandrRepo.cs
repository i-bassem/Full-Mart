using FullMart.Core.Interfaces;
using FullMart.Core.Models;
using FullMart.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Data.Repositories
{
    internal class BrandRepo : BaseRepositiory<Brand>
    {
        private readonly ApplicationDbContext context;

        public BrandRepo(ApplicationDbContext context) : base(context)
        {
        }

        
    }
}
