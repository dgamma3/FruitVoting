using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SportsStore.Controllers {

    [Authorize]
    public class AdminController : Controller {
        private IProductRepository repository;
        private UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        string u;

        private async Task<ApplicationUser> GetCurrentUser()
        {
           return  await userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        
            
        }



        public AdminController(IProductRepository repo, UserManager<ApplicationUser> usrMgr, IHttpContextAccessor httpContextAccessor) {
            repository = repo;
            userManager = usrMgr;
            _httpContextAccessor = httpContextAccessor;

           
      
           
           


        }


        public ViewResult Index(){

            return View(new AdminViewModel()
            {
                user = GetCurrentUser().Result,
                products = repository.Products

            });

    }
        public ViewResult Edit(int productId) =>
            View(repository.Products
                .FirstOrDefault(p => p.ProductID == productId));
        
        [HttpPost]
        public IActionResult Edit(Product product) {
            if (ModelState.IsValid) {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            } else {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId) {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null) {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SeedDatabase() {
            SeedData.EnsurePopulated(HttpContext.RequestServices);
            return RedirectToAction(nameof(Index));
        }
    }
}
