using EquipmentShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.ViewModels
{
    public class ProductsWithMaterials
    {
        public Material material { get; set; }
        public Product product { get; set; }
    }
}
