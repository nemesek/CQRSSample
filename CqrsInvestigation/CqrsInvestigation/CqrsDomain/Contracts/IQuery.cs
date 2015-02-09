using System.Collections.Generic;
using CqrsDomain.Mongo.Model;

namespace CqrsDomain.Contracts
{
    public interface IQuery
    {
        QueryProduct FindProduct(int productId);
        IEnumerable<QueryProduct> FindProducts();
    }
}
