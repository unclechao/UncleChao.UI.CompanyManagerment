using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleChao.CompanyManagerment.Model;

namespace UncleChao.CompanyManagerment.IBLL
{
    public interface IExperienceService
    {
        IEnumerable<Experience> GetAllEmployees();
        Experience GetEmployeeById(int id);
        bool InsertExperience(Experience experience);
        bool UpdateExperience(Experience experience);
        bool DeleteExperience(Experience experience);
        bool DeleteExperienceById(int id);
    }
}
