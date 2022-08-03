using DataLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class DataContextLayer
    {

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new()
            {
                new Employee() { Id = 1, Name = "Rahul Kumar", JoiningDate = DateTime.Now.AddDays(-365), Status = Status.Inactive },
                new Employee() { Id = 2, Name = "Abhinav Sharma", JoiningDate = DateTime.Now.AddDays(-365), Status = Status.Inactive },
                new Employee() { Id = 3, Name = "Preeti Kumari", JoiningDate = DateTime.Now.AddDays(-200), Status = Status.Inactive },
                new Employee() { Id = 4, Name = "Divya Singh", JoiningDate = DateTime.Now.AddDays(-102), Status = Status.Inactive },
                new Employee() { Id = 5, Name = "Dheeraj Tejwani", JoiningDate = DateTime.Now.AddDays(-122), Status = Status.Inactive },
                new Employee() { Id = 6, Name = "Joseph Mathews", JoiningDate = DateTime.Now.AddDays(-110), Status = Status.Inactive },
                new Employee() { Id = 7, Name = "Ranajit Singh", JoiningDate = DateTime.Now.AddDays(-220), Status = Status.Inactive },
                new Employee() { Id = 8, Name = "Ranveer Singh", JoiningDate = DateTime.Now.AddDays(-130), Status = Status.Inactive },
                new Employee() { Id = 9, Name = "Asha Bansal", JoiningDate = DateTime.Now.AddDays(-200), Status = Status.Inactive },
                new Employee() { Id = 10, Name = "Abdul Ahmed", JoiningDate = DateTime.Now.AddDays(10), Status = Status.Inactive },
                new Employee() { Id = 11, Name = "Madakar Rao", JoiningDate = DateTime.Now.AddDays(20), Status = Status.Inactive }
            };

            return employees;
        }

        public static List<EmployeeSalary> GetEmployeesSalary()
        {
            List<EmployeeSalary> employeeSalaries = new()
            {
                new EmployeeSalary() { Id = 1, EmployeeId = 1, Salary = 10000 },
                new EmployeeSalary() { Id = 2, EmployeeId = 2, Salary = 20000 },
                new EmployeeSalary() { Id = 3, EmployeeId = 3, Salary = 15000 },
                new EmployeeSalary() { Id = 4, EmployeeId = 4, Salary = 7000 },
                new EmployeeSalary() { Id = 5, EmployeeId = 5, Salary = 100000 },
                new EmployeeSalary() { Id = 6, EmployeeId = 6, Salary = 70000 },
                new EmployeeSalary() { Id = 7, EmployeeId = 7, Salary = 50000 },
                new EmployeeSalary() { Id = 8, EmployeeId = 8, Salary = 45000 },
                new EmployeeSalary() { Id = 9, EmployeeId = 9, Salary = 24000 },
            };

            return employeeSalaries;
        }

        public static List<EmployeePhoneNumber> GetEmployeePhoneNumbers()
        {
            List<EmployeePhoneNumber> phoneNumber = new List<EmployeePhoneNumber>()
            {
                new EmployeePhoneNumber(){Id=1, EmployeeId=1, PhoneNumbers  =new List<string>() {"847476474784", "847476474781", "847476474782" }},
                new EmployeePhoneNumber(){Id=1, EmployeeId=2, PhoneNumbers  =new List<string>() {"847476474781", "847476474782", "847476474783" }},
                new EmployeePhoneNumber(){Id=1, EmployeeId=3, PhoneNumbers  =new List<string>() {"817476474784", "447476474781", "947476474782" }},
            };

            return phoneNumber;
        }

    }
}
