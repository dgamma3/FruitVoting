using System.Linq;

namespace SportsStore.Models {

    public interface IProductRepository {

        IQueryable<Fruit> Fruit { get; }

        void SaveProduct(Fruit product);

        Fruit DeleteProduct(int productID);
    }
}
