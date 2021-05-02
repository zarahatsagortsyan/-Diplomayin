using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{
    public class HeadSection
    {
        public int HeadSectionId { get; set; }
        public string ImgUrl { get; set; }
        public string HeadTitle{ get; set; }
        public string HeadOverview{ get; set; }
        public string ButtonUrl { get; set; }
    }
}
