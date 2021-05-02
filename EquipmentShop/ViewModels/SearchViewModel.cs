using EquipmentShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.ViewModels
{
    public class SearchViewModel
    {
        public int? page { get; set; }
        public decimal maxPrice { get; set; }
        public string KeyWord { get; set; }
        public List<string> categories { get; set; }
        public List<string> forwhom { get; set; }
        public string GoldKarat { get; set; }
        public string sortOrder { get; set; }
        public List<Product> product { get; set; }
    }
}
