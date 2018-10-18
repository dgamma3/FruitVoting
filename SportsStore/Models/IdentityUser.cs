using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
   
        public class ApplicationUser : IdentityUser
        {
        public string Vote { get; set; }
        public Fruit Fruit { get; set; }
    }

  
}
