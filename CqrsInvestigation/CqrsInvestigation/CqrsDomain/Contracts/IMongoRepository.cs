using System.Collections.Generic;
using CqrsDomain.Mongo.Model;


namespace CqrsDomain.Contracts
{
    public interface IMongoRepository
    {
        void InsertProduct(QueryProduct queryProduct);
        QueryProduct FindProduct(int productId);
        IEnumerable<QueryProduct> FindProducts();
        void UpdateProduct(QueryProduct product);
    }
}
