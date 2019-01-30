using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Department { get; set; }

        public string Gender { get; set; }

        public EmployeeViewModel()
        {
            var homeViewModel = new HomeViewModel();
        }

      

        public static implicit operator EmployeeViewModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                City = employee.City,
                Department = employee.Department,
                EmployeeId = employee.EmployeeId,
                Gender = employee.Gender,
                Name = employee.Name,
            };
        }

        public static implicit operator Employee(EmployeeViewModel vm)
        {
            return new Employee
            {
                City = vm.City,
                Department = vm.Department,
                EmployeeId = vm.EmployeeId,
                Gender = vm.Gender,
                Name = vm.Name,
            };
        }


        

        public Employee Employee;
    }
}
