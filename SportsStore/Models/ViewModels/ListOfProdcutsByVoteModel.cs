using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models.ViewModels {

    public class ListOfProdcutsByVoteModel {


        public List<OrderFruitByVote> productAndVote;

    }

    public class OrderFruitByVote
    {
        public string Name { get; set; }
        public int NumberVoted { get; set; }
    }
}
