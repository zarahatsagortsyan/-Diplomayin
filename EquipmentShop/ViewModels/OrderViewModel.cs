using EquipmentShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.ViewModels
{
    public class OrderViewModel
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
