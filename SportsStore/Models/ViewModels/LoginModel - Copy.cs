using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models.ViewModels {

    public class ListOfProdcutsByVoteModel {


        public List<ProductsAndVote> productAndVote;

    }

    public class ProductsAndVote
    {
        public string Name { get; set; }
        public int NumberVoted { get; set; }
    }
}
