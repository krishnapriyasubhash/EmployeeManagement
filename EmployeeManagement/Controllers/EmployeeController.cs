using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interface;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Employees = _employeeRepository.GetEmployees()
            };
            return View(homeViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeViewModel)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var employee = new Employee
                        {
                            Name = employeeViewModel.Name,
                            City = employeeViewModel.City,
                            Gender = employeeViewModel.Gender,
                            Department = employeeViewModel.Department
                        };
                        _employeeRepository.Create(employee);
                        
                    }
                    transaction.Complete();

                    return RedirectToAction(nameof(Index));

                }

                catch (Exception e)
                {
                    transaction.Dispose();
                    throw e;
                }
            }
                
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employeeViewModel = new EmployeeViewModel();
            //{
            //   Employee = _employeeRepository.GetEmployeeById(id)
            //};
            employeeViewModel = _employeeRepository.GetEmployeeById(id);
            return View(employeeViewModel);
            
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var employee = new Employee
                        {
                            EmployeeId = employeeViewModel.EmployeeId,
                            Name = employeeViewModel.Name,
                            City = employeeViewModel.City,
                            Gender = employeeViewModel.Gender,
                            Department = employeeViewModel.Department
                        };
                        _employeeRepository.Update(employee);
                    }
                    transaction.Complete();

                    return RedirectToAction(nameof(Index));

                }

                catch (Exception e)
                {
                    transaction.Dispose();
                    throw e;
                }
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var employeeViewModel = new EmployeeViewModel();
            employeeViewModel = _employeeRepository.GetEmployeeById(id);
            return View(employeeViewModel);

        }

        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}