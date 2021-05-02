using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string ForWhom { get; set; }
        public string Image { get; set; }
        public string Availability { get; set; }
        public int Views { get; set; }

        public DateTime DateCreated
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }
            set { this.dateCreated = value; }
        }
        private DateTime? dateCreated = null;
    }
}
