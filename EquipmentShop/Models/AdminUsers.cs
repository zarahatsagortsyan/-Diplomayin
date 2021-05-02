using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{
    public class AdminUsers
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AdminVerificationCode { get; set; }
    }
}
