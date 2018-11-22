using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;

namespace Taoxue.Training.Website.Extensions
{
    public static class IDistributedCacheExtension
    {
        public static void Set<T>(this IDistributedCache cache, string key, T obj, DistributedCacheEntryOptions opts = null)
        {
            opts = opts == null ? new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(20) } : opts;
            cache.SetString(key, JsonConvert.SerializeObject(obj), opts);
        }

        public static T Get<T>(this IDistributedCache cache, string key)
        {
            var str = cache.GetString(key);

            if (string.IsNullOrWhiteSpace(str))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
        }
    }
}
