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
    internal class ReviewRepo : BaseRepositiory<Review>, IReviewRepo
    {
        private readonly ApplicationDbContext context;

        public ReviewRepo(ApplicationDbContext context) : base(context)
        {
          this.context = context;
        }
        public async Task< Review> GetReviewByProductId(int productId)
        {

            return await context.Reviews
                .Include(r => r.Product)

                .Include(r => r.AppUser)
                .FirstOrDefaultAsync(r => r.ProductId == productId);
        }
    }
}
