using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleChao.CompanyManagerment.IDao;
using UncleChao.CompanyManagerment.Model;
using UncleChao.CompanyManagerment.SQLDao.CompanyManagermentTableAdapters;

namespace UncleChao.CompanyManagerment.SQLDao
{
    class ExperienceSQLDao : IExperienceDao
    {
        public IEnumerable<Model.Experience> GetAllEntities()
        {
            using (ExperienceSetTableAdapter experienceAdapter = new ExperienceSetTableAdapter())
            {
                var ret = from s in experienceAdapter.GetData()
                          select new Experience { Id = s.Id, Content = s.Content, EmployeeId = s.EmployeeId, Remark = s.Remark };
                return ret;
            }
        }

        public Model.Experience GetEntityById(object id)
        {
            using (ExperienceSetTableAdapter experienceAdapter = new ExperienceSetTableAdapter())
            {
                var ret = from s in experienceAdapter.GetData()
                          where s.Id == (int)id
                          select new Experience { Id = s.Id, Content = s.Content, EmployeeId = s.EmployeeId, Remark = s.Remark };
                return ret.SingleOrDefault();
            }
        }

        public bool InsertEntity(Model.Experience entity)
        {
            bool flag = false;
            using (ExperienceSetTableAdapter experienceAdapter = new ExperienceSetTableAdapter())
            {
                if (experienceAdapter.Insert(entity.Content, entity.Remark, entity.EmployeeId) > 0) flag = true;
            }
            return flag;
        }

        public bool DeleteEntity(Model.Experience entity)
        {
            bool flag = false;
            using (ExperienceSetTableAdapter experienceAdapter = new ExperienceSetTableAdapter())
            {
                if (experienceAdapter.DeleteQuery(entity.Id) > 0) flag = true;
            }
            return flag;
        }

        public bool DeleteEntityById(object id)
        {
            bool flag = false;
            int int_id = Convert.ToInt32(id);
            using (ExperienceSetTableAdapter experienceAdapter = new ExperienceSetTableAdapter())
            {
                if (experienceAdapter.DeleteQuery(int_id) > 0) flag = true;
            }
            return flag;
        }

        public bool UpdateEntity(Model.Experience entity)
        {
            bool flag = false;
            using (ExperienceSetTableAdapter experienceAdapter = new ExperienceSetTableAdapter())
            {
                if (experienceAdapter.UpdateQuery(entity.Content, entity.Remark, entity.EmployeeId, entity.Id) > 0) flag = true;
            }
            return flag;
        }
    }
}
