using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCache
{
    class GenericProxyCache<T>
    {
        public List<T> Get(string cacheItemName, DateTimeOffset dt)
        {
            if (MemoryCache.Default.Get(cacheItemName) == null)
            {
                CacheItemPolicy CacheItemPolicy = new CacheItemPolicy();
                CacheItemPolicy.AbsoluteExpiration = dt;

                MemoryCache.Default.Add(cacheItemName, new List<T>(), CacheItemPolicy);
            }

            return (List<T>)MemoryCache.Default.Get(cacheItemName);
        }

        public List<T> Get(string cacheItemName, double dt_seconds)
        {
            return Get(cacheItemName, new DateTimeOffset(DateTime.Now.AddSeconds(dt_seconds)));
        }

        public List<T> Get(string cacheItemName)
        {
            return Get(cacheItemName, ObjectCache.InfiniteAbsoluteExpiration);
        }
    }
}
