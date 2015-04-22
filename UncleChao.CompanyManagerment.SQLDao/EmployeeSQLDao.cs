using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleChao.CompanyManagerment.IDao;
using UncleChao.CompanyManagerment.Model;
using UncleChao.CompanyManagerment.SQLDao.CompanyManagermentTableAdapters;

namespace UncleChao.CompanyManagerment.SQLDao
{
    public class EmployeeSQLDao : IEmployeeDao
    {
        public IEnumerable<Model.Employee> GetAllEntities()
        {
            using (EmployeeSetTableAdapter employeeAdapter = new EmployeeSetTableAdapter())
            {
                var ret = from s in employeeAdapter.GetData()
                          select new Employee { Id = s.Id, Name = s.Name, Age = s.Age, Remark = s.Remark };
                return ret;
            }
        }

        public Model.Employee GetEntityById(object id)
        {
            using (EmployeeSetTableAdapter employeeAdapter = new EmployeeSetTableAdapter())
            {
                var ret = from s in employeeAdapter.GetData()
                          where s.Id == (int)id
                          select new Employee { Id = s.Id, Name = s.Name, Age = s.Age, Remark = s.Remark };
                return ret.SingleOrDefault();
            }
        }

        public bool InsertEntity(Model.Employee entity)
        {
            bool flag = false;
            using (EmployeeSetTableAdapter employeeAdapter = new EmployeeSetTableAdapter())
            {
                if (employeeAdapter.Insert(entity.Name, entity.Age, entity.Remark) > 0) flag = true;
            }
            return flag;
        }

        public bool DeleteEntity(Model.Employee entity)
        {
            bool flag = false;
            using (EmployeeSetTableAdapter employeeAdapter = new EmployeeSetTableAdapter())
            {
                if (employeeAdapter.Delete(entity.Id) > 0) flag = true;
            }
            return flag;
        }

        public bool DeleteEntityById(object id)
        {
            bool flag = false;
            int int_id = Convert.ToInt32(id);
            using (EmployeeSetTableAdapter employeeAdapter = new EmployeeSetTableAdapter())
            {
                if (employeeAdapter.Delete(int_id) > 0) flag = true;
            }
            return flag;
        }

        public bool UpdateEntity(Model.Employee entity)
        {
            bool flag = false;
            using (EmployeeSetTableAdapter employeeAdapter = new EmployeeSetTableAdapter())
            {
                if (employeeAdapter.Update(entity.Name, entity.Age, entity.Remark, entity.Id) > 0) flag = true;
            }
            return flag;
        }
    }
}
