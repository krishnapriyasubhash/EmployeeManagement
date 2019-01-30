using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModels
{
    public class HomeViewModel
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Department { get; set; }

        public string Gender { get; set; }

        public IEnumerable<Employee> Employees;
    }
}
