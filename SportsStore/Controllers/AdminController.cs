using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        private UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContext;
        private AppIdentityDbContext context;


        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await userManager.GetUserAsync(httpContext.HttpContext.User);
        }

        public AdminController(IProductRepository repo, UserManager<ApplicationUser> usrMgr, IHttpContextAccessor httpContextAccessor, AppIdentityDbContext ctx)
        {
            repository = repo;
            userManager = usrMgr;
            httpContext = httpContextAccessor;
            context = ctx;
        }


        public ViewResult Index()
        {
             context.Users.Include(p => p.Fruit).ToArray();

            return View(new AdminViewModel()
            {
                User = GetCurrentUser().Result,
                Fruits = repository.Fruit
            });
        }

        public IActionResult Add(int ProductID)
        {
            var newProduct = repository.Fruit.First(x => x.FruitID == ProductID);

            var currentUser = GetCurrentUser().Result;
            currentUser.Fruit = newProduct;
            context.SaveChanges();

            return RedirectToAction("Index");

        }
        

        [HttpPost]
        public IActionResult SeedDatabase()
        {
            SeedData.EnsurePopulated(HttpContext.RequestServices);
            return RedirectToAction(nameof(Index));
        }
    }
}
