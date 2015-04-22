using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleChao.CompanyManagerment.IDao;
using UncleChao.CompanyManagerment.Model;

namespace UncleChao.CompanyManagerment.EFDao
{
    public class EmployeeEFDao : IEmployeeDao
    {
        private CompanyManagermentContainer companyManagermentDB = new CompanyManagermentContainer();

        public IEnumerable<UncleChao.CompanyManagerment.Model.Employee> GetAllEntities()
        {
            return companyManagermentDB.EmployeeSet.AsEnumerable<Employee>();
        }

        public UncleChao.CompanyManagerment.Model.Employee GetEntityById(object id)
        {
            int int_id = Convert.ToInt32(id);
            return companyManagermentDB.EmployeeSet.Where<Employee>(s => s.Id == int_id).SingleOrDefault();
        }

        public bool InsertEntity(UncleChao.CompanyManagerment.Model.Employee entity)
        {
            bool flag = false;
            companyManagermentDB.EmployeeSet.Add(entity);
            if (companyManagermentDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool DeleteEntity(UncleChao.CompanyManagerment.Model.Employee entity)
        {
            bool flag = false;
            companyManagermentDB.EmployeeSet.Remove(entity);
            if (companyManagermentDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool DeleteEntityById(object id)
        {
            bool flag = false;
            companyManagermentDB.EmployeeSet.Remove(GetEntityById(id));
            if (companyManagermentDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool UpdateEntity(UncleChao.CompanyManagerment.Model.Employee entity)
        {
            bool flag = false;
            var oldEntity = companyManagermentDB.EmployeeSet.Where<Employee>(s => s.Id == entity.Id).SingleOrDefault();
            oldEntity.Name = entity.Name;
            oldEntity.Age = entity.Age;
            oldEntity.Remark = entity.Remark;
            oldEntity.Experience = entity.Experience;
            //companyManagermentDB.EmployeeSet.Attach(entity);
            //companyManagermentDB.Entry<Employee>(entity).State = System.Data.EntityState.Modified;
            if (companyManagermentDB.SaveChanges() > 0) flag = true;
            return flag;
        }
    }
}
