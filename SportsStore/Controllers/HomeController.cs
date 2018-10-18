using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers {

    public class HomeController : Controller {
        private IProductRepository repository;
    
        private UserManager<ApplicationUser> userManager;

        public HomeController(IProductRepository repo,  UserManager<ApplicationUser> usrMgr) {
            repository = repo;
       
            userManager = usrMgr;
        }

        public ViewResult Index(string returnUrl) {
            var fruitsVotedFor = userManager.Users.Include(p => p.Product).Select(x => x.Product).ToArray();
  
            var fruitsVotedForGrouped = fruitsVotedFor.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count()).OrderBy(v => v.Value);



            var fruitsVotedForByName2 = fruitsVotedForGrouped.Select(pp => new ProductsAndVote
            {
                Name = pp.Key.Name,
                NumberVoted = pp.Value
            });


         var fruitsNotVotedFor = repository.Products.Select(x => x.Name).ToList().Except(fruitsVotedForByName2.Select(x => x.Name).ToList());
           var fruitsNotVotedForObject =  fruitsNotVotedFor.Select(p => new ProductsAndVote
            {
                Name = p,
                NumberVoted = 0
            });

            var val = new System.Collections.Generic.List<ProductsAndVote>();
            val.AddRange(fruitsVotedForByName2);
            val.AddRange(fruitsNotVotedForObject);

           
   
            return View(new ListOfProdcutsByVoteModel()
            {
                productAndVote = val
            });
        }

        
    }
}