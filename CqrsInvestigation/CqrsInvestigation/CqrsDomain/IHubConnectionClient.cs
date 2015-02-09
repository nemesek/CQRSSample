using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDomain
{
    public interface IHubConnectionClient
    {
        IHubProxy CreateHubProxy(string hubName);
    }
}
