using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UncleChao.CompanyManagerment.AbstractFactory
{
    public class DaoCache
    {
        public static object GetDaoCache(string key)
        {
            System.Web.Caching.Cache daoCache = HttpRuntime.Cache;
            return daoCache.Get(key);
        }

        public static void InsertDaoCache(string key, object value)
        {
            System.Web.Caching.Cache daoCache = HttpRuntime.Cache;
            if (GetDaoCache(key) == null)
            {
                daoCache.Insert(key, value);
            }
        }
    }
}
