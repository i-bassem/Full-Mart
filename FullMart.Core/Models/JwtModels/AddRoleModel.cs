using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMart.Core.Models.JwtModels
{
    public class AddRoleModel
    {
        [Required]
        public string User_Id { get; set; }
        [Required]

        public string Role { get; set; }
    }
}
