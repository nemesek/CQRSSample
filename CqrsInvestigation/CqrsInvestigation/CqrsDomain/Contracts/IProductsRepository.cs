using System.Collections.Generic;
using CqrsDomain.Mongo.Model;
using CqrsDomain.Northwind.Model;

namespace CqrsDomain.Contracts
{
    public interface IProductsRepository
    {
        Product FindByKey(int key);
        IEnumerable<Product> FindAll();
        void SaveChanges();
        void SaveChanges(Product product);
        void SaveProductCategoryChanges(Product product);
        void UpdateProduct(QueryProduct queryProduct);
    }
}
