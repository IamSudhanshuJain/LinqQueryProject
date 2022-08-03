using BusinessLayer.Models;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class HomeService
    {

        public HomeService()
        {
        }
        /// <summary>
        /// Get All Employees from the data repository
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            return DataContextLayer.GetEmployees();
        }
        /// <summary>
        /// Get All Active Employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAllActiveEmployees()
        {
            return DataContextLayer.GetEmployees().Where(x => x.Status == Status.Active).ToList();
        }

        /// <summary>
        /// Get All InActive Employees
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllInActiveEmployees()
        {
            return DataContextLayer.GetEmployees().Where(x => x.Status == Status.Inactive).ToList();
        }


        /// <summary>
        /// Using Method Linq and get N employees
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployeesBasedOnN_UsingMethod(int n)
        {
            var employees = DataContextLayer.GetEmployees();
            return employees.Take(n).ToList();
        }
        /// <summary>
        /// Using Query Linq and get N employees
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeesBasedOnN_UsingQuery(int n)
        {
            var employees = DataContextLayer.GetEmployees();
            var result = (from employee in employees
                          select employee).Take(n).ToList();

            return result;
        }

        /// <summary>
        /// Using Query Linq to do inner Join and get N employees
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<EmployeeSalaryModel> GetEmployeesInnerJoinToSalary_UsingQuery(int n)
        {
            var employees = DataContextLayer.GetEmployees();
            var salaries = DataContextLayer.GetEmployeesSalary();

            var result = (from employee in employees
                          join salary in salaries
                          on employee.Id equals salary.EmployeeId
                          select new EmployeeSalaryModel()
                          {
                              EmployeeId = employee.Id,
                              EmployeeName = employee.Name,
                              EmployeeStatus = employee.Status.ToString(),
                              Salary = salary.Salary

                          }).Take(n).ToList();

            return result;

        }

        /// <summary>
        /// Using Method Linq to do inner Join and get N employees
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<EmployeeSalaryModel> GetEmployeesInnerJoinToSalary_UsingMethod(int n)
        {
            var employees = DataContextLayer.GetEmployees();
            var salaries = DataContextLayer.GetEmployeesSalary();

            var result = employees.Join(salaries, employee => employee.Id, salary => salary.EmployeeId,
                (employee, salary) => new EmployeeSalaryModel()
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.Name,
                    EmployeeStatus = employee.Status.ToString(),
                    Salary = salary.Salary

                }).Take(n).ToList();

            return result;
        }

        /// <summary>
        ///It is demo purpose to get Salary of Employee based on choice otherwise good to create separate methods
        /// </summary>
        /// <param name="highestSalary"></param>
        /// <returns></returns>
        public EmployeeSalaryModel GetHighestAndLowestSalaryOfEmployee(bool highestSalary = true)
        {
            EmployeeSalaryModel getSalaryEmployee;

            var output = (from employee in DataContextLayer.GetEmployees()
                          join salary in DataContextLayer.GetEmployeesSalary() on employee.Id equals salary.EmployeeId
                          select new EmployeeSalaryModel()
                          {
                              EmployeeId = employee.Id,
                              EmployeeName = employee.Name,
                              EmployeeStatus = employee.Status.ToString(),
                              Salary = salary.Salary
                          });

            if (highestSalary)
                getSalaryEmployee = output.OrderByDescending(x => x.Salary).FirstOrDefault();
            else
                getSalaryEmployee = output.OrderBy(x => x.Salary).FirstOrDefault();


            return getSalaryEmployee;
        }
        /// <summary>
        /// Sum of total salary
        /// </summary>
        /// <returns></returns>
        public int GetTotalSalaryDistributedToEmployee()
        {
            return DataContextLayer.GetEmployeesSalary().Sum(x => x.Salary);
        }

        /// <summary>
        /// Left Join Using Query Syntax
        /// </summary>
        /// <returns></returns>
        public List<EmployeeSalaryModel> LeftJoin_UsingQuery()
        {
            var result = from employee in DataContextLayer.GetEmployees()
                         join salary in DataContextLayer.GetEmployeesSalary()
                         on employee.Id equals salary.EmployeeId
                         into employeeSalaryGroup
                         from empSalaryGroup in employeeSalaryGroup.DefaultIfEmpty()
                         select new EmployeeSalaryModel()
                          {
                                 EmployeeId = employee.Id,
                              EmployeeName = employee.Name,
                              EmployeeStatus = employee.Status.ToString(),
                              Salary = empSalaryGroup?.Salary
                          };

            return result.ToList();
        }
        /// <summary>
        /// Left Join Using Method Syntax
        /// </summary>
        /// <returns></returns>
        public List<EmployeeSalaryModel> LeftJoin_UsingMethod()
        {

            var employees = DataContextLayer.GetEmployees();
            var salaries = DataContextLayer.GetEmployeesSalary();

            var result = employees.GroupJoin(salaries, emp => emp.Id, salary => salary.EmployeeId,
                (emp, salary) => new { emp, salary })
                .SelectMany(x => x.salary.DefaultIfEmpty(), (employee, salary) => new EmployeeSalaryModel()
                {
                    EmployeeId = employee.emp.Id,
                    EmployeeName = employee.emp.Name,
                    EmployeeStatus = employee.emp.Status.ToString(),
                    Salary = salary?.Salary
                });

            return result.ToList();

        }

        /// <summary>
        /// SelectMany -- Flatten the queries and return lists of lists
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public List<string> GetPhoneNumbers_UsingSelectMany(int employeeId)
        {
            var employeePhoneNumbers = DataContextLayer.GetEmployeePhoneNumbers();

            //For test, debug and see the list
            var selectEmployeePhoneNumbers = employeePhoneNumbers.Where(x=>x.EmployeeId == employeeId).Select(x=>x.PhoneNumbers);

            //debug and check, it picks inner list 
            var selectManyEmployeePhoneNumbers = employeePhoneNumbers.Where(x => x.EmployeeId == employeeId).SelectMany(x => x.PhoneNumbers);

            return selectManyEmployeePhoneNumbers.ToList();
        }

        /// <summary>
        /// Get single Employee using Single Linq based on EmployeeId.
        ///Prefer to using with when searching with primary key.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployeeById(int employeeId)
        {
            return DataContextLayer.GetEmployees().FirstOrDefault(x => x.Id == employeeId);
        }


    }
}
