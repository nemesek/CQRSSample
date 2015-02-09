using CqrsDal.Contracts;
using CqrsDomain.Mongo.Model;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace CqrsDal.Concrete
{
    public class ProductMessagePusher : IPushProductMessages
    {
        private const string HubName = "MessageHub";
        private const string Connection = "http://localhost:43656/";
        private readonly HubConnection _hubConnection;
        private readonly IHubProxy _messageHub;

        public ProductMessagePusher()
        {
            _hubConnection = new HubConnection(Connection);
            _messageHub = _hubConnection.CreateHubProxy(HubName);
            _hubConnection.Start().Wait();
        }

        public ProductMessagePusher(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
            _messageHub = _hubConnection.CreateHubProxy(HubName);
            _hubConnection.Start().Wait();
        }

        public void ResetProductTable()
        {
            var methodToInvoke = "ResetProductTable";
            _messageHub.Invoke(methodToInvoke).Wait();
        }

        public void PushUpdatedProduct(QueryProduct product)
        {
            var methodToInvoke = "PushUpdateProduct";
            _messageHub.Invoke(methodToInvoke, product).Wait();
        }

        public void PushUpdateMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
