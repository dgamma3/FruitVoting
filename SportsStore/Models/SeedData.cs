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
                        Name = "Kayak"
                    
                    },
                    new Fruit {
                        Name = "Lifejacket"
                    },
                    new Fruit {
                        Name = "Soccer Ball"
                    },
                    new Fruit {
                        Name = "Corner Flags"
                    },
                    new Fruit {
                        Name = "Stadium"
                    },
                    new Fruit {
                        Name = "Thinking Cap"
                    },
                    new Fruit {
                        Name = "Unsteady Chair"
                    },
                    new Fruit {
                        Name = "Human Chess Board"
                    },
                    new Fruit {
                        Name = "Bling-Bling King"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
