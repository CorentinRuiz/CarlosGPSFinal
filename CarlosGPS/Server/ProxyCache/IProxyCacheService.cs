using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace ProxyCache
{
    [ServiceContract]
    public interface IProxyCacheService
    {
        [OperationContract]
        List<Station> GetAllStations();
    }
}
