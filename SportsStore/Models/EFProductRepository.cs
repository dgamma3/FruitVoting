using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models {

    public class EFProductRepository : IProductRepository {
        private AppIdentityDbContext context;

        public EFProductRepository(AppIdentityDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Fruit> Fruit => context.Products;

        public void SaveProduct(Fruit product) {
            if (product.FruitID == 0) {
                context.Products.Add(product);
            } else {
                Fruit dbEntry = context.Products
                    .FirstOrDefault(p => p.FruitID == product.FruitID);
                if (dbEntry != null) {
                    dbEntry.Name = product.Name;
  
                }
            }
            context.SaveChanges();
        }

        public Fruit DeleteProduct(int productID) {
            Fruit dbEntry = context.Products
                .FirstOrDefault(p => p.FruitID == productID);
            if (dbEntry != null) {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
