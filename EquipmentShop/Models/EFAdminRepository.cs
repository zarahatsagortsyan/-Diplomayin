using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{
    public class EFAdminRepository:IAdminRepository
    {
        private readonly ApplicationDbContext context;
        public EFAdminRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<HeadSection> HeadSections => context.HeadSections;
        public IEnumerable<AboutSection> AboutSections => context.AboutSections;
        public IEnumerable<StaffSection> StaffSections => context.StaffSections;
        public IEnumerable<ContactSection> ContactSections => context.ContactSections;
        public IEnumerable<Category> Categories => context.Categories;
        public IEnumerable<Material> Materials => context.Materials;
        public IEnumerable<MaterialList> materialLists => context.materialLists;
        public IEnumerable<ForWhom> ForWhoms => context.ForWhoms;
        
    }
}
