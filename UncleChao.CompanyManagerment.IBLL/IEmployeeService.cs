using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncleChao.CompanyManagerment.AbstractFactory;
using UncleChao.CompanyManagerment.IDao;
using UncleChao.CompanyManagerment.Model;

namespace UncleChao.CompanyManagerment.IBLL
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        bool InsertEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool DeleteEmployeeById(int id);
    }
}
