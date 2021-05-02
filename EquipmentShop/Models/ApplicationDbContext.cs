using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EquipmentShop.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<HeadSection> HeadSections { get; set; }
        public DbSet<ContactSection> ContactSections { get; set; }
        public DbSet<StaffSection> StaffSections { get; set; }
        public DbSet<AboutSection> AboutSections { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ForWhom> ForWhoms { get; set; }
        public DbSet<MaterialList> materialLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BasketProducts> BasketProducts { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<AdminUsers> AdminUsers { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
    }
}
