using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleChao.CompanyManagerment.AbstractFactory;
using UncleChao.CompanyManagerment.IBLL;
using UncleChao.CompanyManagerment.IDao;

namespace UncleChao.CompanyManagerment.BLL
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeDao employeeDao = DaoFactory.GetEmployeeDao();
        public IEnumerable<Model.Employee> GetAllEmployees()
        {
            return employeeDao.GetAllEntities();
        }

        public Model.Employee GetEmployeeById(int id)
        {
            return employeeDao.GetEntityById(id);
        }

        public bool InsertEmployee(Model.Employee employee)
        {
            return employeeDao.InsertEntity(employee);
        }

        public bool UpdateEmployee(Model.Employee employee)
        {
            return employeeDao.UpdateEntity(employee);
        }

        public bool DeleteEmployee(Model.Employee employee)
        {
            return employeeDao.DeleteEntity(employee);
        }

        public bool DeleteEmployeeById(int id)
        {
            return employeeDao.DeleteEntityById(id);
        }
    }
}
