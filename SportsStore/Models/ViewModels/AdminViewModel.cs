using Microsoft.AspNetCore.Identity;
using SportsStore.Models;
using System.Collections.Generic;

namespace SportsStore.Models.ViewModels
{

    public class AdminViewModel
    {
        public IEnumerable<Fruit> Fruits;
        public ApplicationUser User { get; set; }
    }
}
