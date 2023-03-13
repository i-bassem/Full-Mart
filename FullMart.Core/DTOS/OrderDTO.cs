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

        public string Username { get; set; }

        public DateTime OrderDate { get; set; }

        [Range(1, 3)]
        public Status Status { get; set; }


        public List<string> ProductNames { get; set; } = new List<string>();

    }
}
