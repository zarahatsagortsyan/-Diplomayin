using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{

    public class AboutSection
    {
        public int ID { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Dest { get; set; }
    }
}
