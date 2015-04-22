using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using UncleChao.CompanyManagerment.IDao;

namespace UncleChao.CompanyManagerment.AbstractFactory
{
    public class DaoFactory
    {
        private static readonly string daoPath = ConfigurationManager.AppSettings["DaoPath"].ToString();

        public static object CreateDao(string objType)
        {
            var daoCache = DaoCache.GetDaoCache(objType);
            if (daoCache == null)
            {
                daoCache = Assembly.Load(daoPath).CreateInstance(objType);
                DaoCache.InsertDaoCache(objType, daoCache);
            }
            return daoCache;
        }

        public static IEmployeeDao GetEmployeeDao()
        {
            var temparr = daoPath.Split('.');
            StringBuilder sb = new StringBuilder();
            sb.Append(daoPath).Append(".Employee").Append(temparr[temparr.Length - 1]);
            return CreateDao(sb.ToString()) as IEmployeeDao;
        }

        public static IExperienceDao GetExperienceDao()
        {
            var temparr = daoPath.Split('.');
            StringBuilder sb = new StringBuilder();
            sb.Append(daoPath).Append(".Experience").Append(temparr[temparr.Length - 1]);
            return CreateDao(sb.ToString()) as IExperienceDao;
        }
    }
}
