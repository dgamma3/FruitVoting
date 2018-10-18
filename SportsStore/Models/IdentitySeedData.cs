using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace SportsStore.Models
{


    public static class IdentitySeedData
    {
        private const string adminUser1 = "Jane";
        private const string adminPassword1 = "Secret123$";
        private const string adminUser2 = "John";
        private const string adminPassword2 = "Secret123$";
        public static async Task EnsurePopulated(UserManager<ApplicationUser>
        userManager)
        {
            ApplicationUser user1 = await userManager.FindByIdAsync(adminUser1);
            if (user1 == null)
            {
                user1 = new ApplicationUser()
                {
                    UserName = adminUser1,
                   
                    
                }; 
                await userManager.CreateAsync(user1, adminPassword1);
              
            }
            ApplicationUser user2 = await userManager.FindByIdAsync(adminUser2);
            if (user2== null)
            {
                user2 = new ApplicationUser()
                {
                    UserName = adminUser2                  
           
                };
                await userManager.CreateAsync(user2, adminPassword2);

            }
        }
    }
}

