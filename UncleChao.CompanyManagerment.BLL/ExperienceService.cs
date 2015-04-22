using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleChao.CompanyManagerment.AbstractFactory;
using UncleChao.CompanyManagerment.IBLL;
using UncleChao.CompanyManagerment.IDao;

namespace UncleChao.CompanyManagerment.BLL
{
    public class ExperienceService : IExperienceService
    {
        private IExperienceDao experienceDao = DaoFactory.GetExperienceDao();
        public IEnumerable<Model.Experience> GetAllEmployees()
        {
            return experienceDao.GetAllEntities();
        }

        public Model.Experience GetEmployeeById(int id)
        {
            return experienceDao.GetEntityById(id);
        }

        public bool InsertExperience(Model.Experience experience)
        {
            return experienceDao.InsertEntity(experience);
        }

        public bool UpdateExperience(Model.Experience experience)
        {
            return experienceDao.UpdateEntity(experience);
        }

        public bool DeleteExperience(Model.Experience experience)
        {
            return experienceDao.DeleteEntity(experience);
        }

        public bool DeleteExperienceById(int id)
        {
            return experienceDao.DeleteEntityById(id);
        }
    }
}
