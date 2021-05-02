using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{
    public interface IAdminRepository
    {
        IEnumerable<ContactSection> ContactSections { get; }
        IEnumerable<AboutSection> AboutSections { get; }
        IEnumerable<StaffSection> StaffSections { get; }
        IEnumerable<HeadSection> HeadSections { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<Material> Materials { get; }
    }
}
