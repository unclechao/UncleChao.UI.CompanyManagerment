using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleChao.CompanyManagerment.IDao;
using UncleChao.CompanyManagerment.Model;

namespace UncleChao.CompanyManagerment.EFDao
{
    public class ExperienceEFDao : IExperienceDao
    {
        private CompanyManagermentContainer companyManagermentDB = new CompanyManagermentContainer();

        public IEnumerable<Model.Experience> GetAllEntities()
        {
            return companyManagermentDB.ExperienceSet.AsEnumerable<Experience>();
        }

        public Model.Experience GetEntityById(object id)
        {
            int int_id = Convert.ToInt32(id);
            return companyManagermentDB.ExperienceSet.Where<Experience>(s => s.Id == int_id).SingleOrDefault();
        }

        public bool InsertEntity(Model.Experience entity)
        {
            bool flag = false;
            companyManagermentDB.ExperienceSet.Add(entity);
            if (companyManagermentDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool DeleteEntity(Model.Experience entity)
        {
            bool flag = false;
            companyManagermentDB.ExperienceSet.Remove(entity);
            if (companyManagermentDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool DeleteEntityById(object id)
        {
            bool flag = false;
            companyManagermentDB.ExperienceSet.Remove(GetEntityById(id));
            if (companyManagermentDB.SaveChanges() > 0) flag = true;
            return flag;
        }

        public bool UpdateEntity(Model.Experience entity)
        {
            bool flag = false;
            var oldEntity = companyManagermentDB.ExperienceSet.Where<Experience>(s => s.Id == entity.Id).SingleOrDefault();
            oldEntity.Content = entity.Content;
            oldEntity.EmployeeId = entity.EmployeeId;
            oldEntity.Remark = entity.Remark;
            //companyManagermentDB.ExperienceSet.Attach(entity);
            //companyManagermentDB.Entry<Experience>(entity).State = System.Data.EntityState.Modified;
            if (companyManagermentDB.SaveChanges() > 0) flag = true;
            return flag;
        }
    }
}
