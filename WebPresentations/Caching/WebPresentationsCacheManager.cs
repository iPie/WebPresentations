using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common;

namespace WebPresentations.Caching
{
    public class WebPresentationsCacheManager:ICacheManager
    {
        private ICacheManager primitivesCache;
        
        public WebPresentationsCacheManager()
        {
            this.primitivesCache = CacheFactory.GetCacheManager();
        }

        public void Add(string key, object value)
        {
            primitivesCache.Add(key,value);
        }

        public void Add(string key, object value, CacheItemPriority scavengingPriority, ICacheItemRefreshAction refreshAction, params ICacheItemExpiration[] expirations)
        {
            
            primitivesCache.Add(key, value, scavengingPriority, refreshAction, expirations);
        }

        public bool Contains(string key)
        {
            return primitivesCache.Contains(key);
        }

        public void Flush()
        {
            primitivesCache.Flush();
        }

        public object GetData(string key)
        {
            return primitivesCache.GetData(key);
        }

        public void Remove(string key)
        {
            primitivesCache.Remove(key);
        }

        public int Count
        {
            get { return primitivesCache.Count; }
        }

        public object this[string key]
        {
            get { return primitivesCache[key]; }
        }
    }
}