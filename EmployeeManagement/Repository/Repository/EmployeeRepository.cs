using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Create(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@Name", employee.Name);
                    ObjParm.Add("@City", employee.City);
                    ObjParm.Add("@Department", employee.Department);
                    ObjParm.Add("@Gender", employee.Gender);
                    connection.Open();
                    connection.Execute("AddEmployee", ObjParm, commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void Delete(int Id)
        {
           
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@EmpId", Id);
                    connection.Query<Employee>("DeleteEmployee", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
              
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Employee GetEmployeeById(int Id)
        {
            Employee employee;
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@EmpId", Id);
                    employee=connection.Query<Employee>("GetEmployee", ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                return employee;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            IEnumerable<Employee> employeeList;
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    
                    connection.Open();
                    employeeList = SqlMapper.Query<Employee>(connection, "GetAllEmployees").ToList();
                    connection.Close();
                }
                return employeeList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Employee employee)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@EmpId", employee.EmployeeId);
                    ObjParm.Add("@Name", employee.Name);
                    ObjParm.Add("@City", employee.City);
                    ObjParm.Add("@Department", employee.Department);
                    ObjParm.Add("@Gender", employee.Gender);
                    connection.Open();
                    connection.Execute("UpdateEmployee", ObjParm, commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
