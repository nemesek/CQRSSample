using CqrsDomain.Mongo.Model;

namespace CqrsDomain.Contracts
{
    public interface ICommand
    {
        void UpdateProduct(QueryProduct queryProduct);
    }
}
