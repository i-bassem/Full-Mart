using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class OrderCreateDTO
    {
        public string UserId { get; set; }
        public List<OrderProductCreateDTO> OrderProducts { get; set; }
    }

}
