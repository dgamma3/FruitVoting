using SportsStore.Models;
using System.Collections.Generic;

namespace SportsStore.Models.ViewModels {

    public class CartIndexViewModel {
        public IEnumerable<Product> products;
        public ApplicationUser user { get; set; }
   
    }
}
