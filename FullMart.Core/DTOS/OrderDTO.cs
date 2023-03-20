using FullMart.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FullMart.Core.DTOS
{
    public class OrderDTO
    {

        public int Id { get; set; }
        public List<OrderProductDTO> OrderProductDTOs { get; set; }

    }
}
