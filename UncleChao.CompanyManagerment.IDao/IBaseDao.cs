using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncleChao.CompanyManagerment.IDao
{
    public interface IBaseDao<T> where T : class
    {
        IEnumerable<T> GetAllEntities();
        T GetEntityById(object id);
        bool InsertEntity(T entity);
        bool DeleteEntity(T entity);
        bool DeleteEntityById(object id);
        bool UpdateEntity(T entity);
    }
}
