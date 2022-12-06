using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.Json;
using static System.Collections.Specialized.BitVector32;

namespace ProxyCache
{
    public class ProxyCacheService : IProxyCacheService
    {
        public List<Station> GetAllStations()
        {
            var proxyCache = new GenericProxyCache<Station>();
            var allStations = proxyCache.Get("all_stations", 60 * 3); // store the stations for 3 minutes in the cache

            if (!allStations.Any())
            {
                Console.WriteLine("Proxy: Cache empty -> request to JCDecaux's API");
                var jcdRequest = new JCDRequest();
                allStations.AddRange(JsonSerializer.Deserialize<List<Station>>(jcdRequest.GetAllStations()));
            }

            return allStations;
        }
    }
}
