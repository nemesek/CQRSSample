using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsDomain.Mongo.Model;

namespace CqrsDomain.Contracts
{
    public interface IProductMessagePush
    {
        void PushUpdateProduct(QueryProduct queryProduct);
        void Update(string message);
        void UpdateProductCategoryName(QueryProduct queryProduct);
    }
}
