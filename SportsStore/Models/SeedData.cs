using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace SportsStore.Models {

    public static class SeedData {

        public static void EnsurePopulated(IServiceProvider services) {
            AppIdentityDbContext context = services.GetRequiredService<AppIdentityDbContext>();
            //context.Database.Migrate();
            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Fruit {
                        Name = "Apple"
                    },
                    new Fruit {
                        Name = "Orange"
                    },
                    new Fruit {
                        Name = "Banana"
                    },
                    new Fruit {
                        Name = "Pineapples"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
