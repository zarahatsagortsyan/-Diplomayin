using EquipmentShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.ViewModels
{
    public class BasketProductsViewModel
    {
        public Product Product { get; set; }
        public BasketProducts Basket { get; set; }
    }
}
