using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentShop.Models
{
    public class EFProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;        
        }
        public IEnumerable<Product> Products => context.Products;
    }
}
