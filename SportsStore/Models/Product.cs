using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models {

    public class Fruit {
        public int FruitID { get; set; }
        
        public string Name { get; set; }


    }
}
