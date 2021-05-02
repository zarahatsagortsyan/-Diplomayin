using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{
    public class BasketProducts
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public string Category { get; set; }
        public string ForWhom { get; set; }


    }
}
