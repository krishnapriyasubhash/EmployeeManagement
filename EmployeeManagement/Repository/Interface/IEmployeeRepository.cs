using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Interface
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);

        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeById(int Id);

        void Update(Employee employee);

        void Delete(int Id);
    }
}
