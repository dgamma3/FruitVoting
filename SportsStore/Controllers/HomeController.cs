using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Controllers
{

    public class HomeController : Controller {
        private IProductRepository repository;
    
        private UserManager<ApplicationUser> userManager;

        public HomeController(IProductRepository repo,  UserManager<ApplicationUser> usrMgr) {
            repository = repo;       
            userManager = usrMgr;
        }

        public ViewResult Index(string returnUrl)
        {
            List<OrderFruitByVote> orderFruitByVote = OrderFruitByVote();

            return View(new ListOfProdcutsByVoteModel()
            {
                productAndVote = orderFruitByVote
            });
        }

        private System.Collections.Generic.List<OrderFruitByVote> OrderFruitByVote()
        {
            IEnumerable<OrderFruitByVote> fruitsVotedOn = FruitsVotedOn();
            IEnumerable<OrderFruitByVote> fruitsNotVotedForObject = FruitsNotVotedOn(fruitsVotedOn);

            var val = new List<OrderFruitByVote>();

            val.AddRange(fruitsVotedOn);
            val.AddRange(fruitsNotVotedForObject);

            return val;
        }

        private IEnumerable<OrderFruitByVote> FruitsNotVotedOn(IEnumerable<OrderFruitByVote> fruitsVotedOn)
        {
            var allFruits = repository.Fruit.Select(x => x.Name).ToList();
            var fruitNotVotedFor = allFruits.Except(fruitsVotedOn.Select(x => x.Name).ToList());
            var fruitByVotesObject = fruitNotVotedFor.Select(p => new OrderFruitByVote
            {
                Name = p,
                NumberVoted = 0
            });
            return fruitByVotesObject;
        }

        private IEnumerable<OrderFruitByVote> FruitsVotedOn()
        {
            var fruitByVotes = userManager.Users.Include(p => p.Fruit).Select(p => p.Fruit).Where(p => p != null).ToArray();

            var fruitByVotesGroupes = fruitByVotes.GroupBy(p => p).ToDictionary(g => g.Key, g => g.Count()).OrderBy(v => v.Value);

            var fruitByVotesObject = fruitByVotesGroupes.Select(fruitByVotesGroup => new OrderFruitByVote
            {
                Name = fruitByVotesGroup.Key.Name,
                NumberVoted = fruitByVotesGroup.Value
            });
            return fruitByVotesObject;
        }
    }
}