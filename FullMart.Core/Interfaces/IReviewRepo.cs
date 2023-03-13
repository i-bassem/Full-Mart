using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Interfaces
{
    public interface IReviewRepo :IBaseRepo<Review>
    {

        Task<Review> GetReviewByProductId(int productId);

    }
}
