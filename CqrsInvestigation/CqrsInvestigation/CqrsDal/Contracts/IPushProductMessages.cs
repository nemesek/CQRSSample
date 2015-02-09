using CqrsDomain.Mongo.Model;

namespace CqrsDal.Contracts
{
    public interface IPushProductMessages
    {
        void PushUpdatedProduct(QueryProduct product);
        void PushUpdateMessage(string message);
        void ResetProductTable();
    }
}