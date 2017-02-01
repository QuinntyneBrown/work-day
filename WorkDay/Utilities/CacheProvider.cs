using WorkDay.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkDay.Utilities
{
    public class CacheProvider : ICacheProvider
    {
        public ICache GetCache()
        {
            return RedisCache.Current;
        }
    }
}
