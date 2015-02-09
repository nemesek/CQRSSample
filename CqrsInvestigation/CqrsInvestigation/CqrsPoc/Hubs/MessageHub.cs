using System.Globalization;
using CqrsDomain.Mongo.Model;
using Microsoft.AspNet.SignalR;

namespace CqrsPoc.Hubs
{
    public class MessageHub : Hub
    {
        public void ResetProductTable()
        {
            Clients.All.resetProductTable();
        }

        public void PushUpdateProduct(QueryProduct product) 
        {
            Clients.All.updateProductDetails(product);
        }
    }
}