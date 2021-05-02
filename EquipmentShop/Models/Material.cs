using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{
    public class Material
    {
        public int Id { get; set; }    
        public string Name { get; set; }
        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
