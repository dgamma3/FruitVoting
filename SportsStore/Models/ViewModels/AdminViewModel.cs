using Microsoft.AspNetCore.Identity;
using SportsStore.Models;
using System.Collections.Generic;

namespace SportsStore.Models.ViewModels
{

    public class AdminViewModel
    {
        public IEnumerable<Product> products;
        public ApplicationUser user { get; set; }
        public string ReturnUrl { get; set; }
    }
}
