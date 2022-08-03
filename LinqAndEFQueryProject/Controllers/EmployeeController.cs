using BusinessLayer;
using BusinessLayer.Models;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace LinqAndEFQueryProject.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly HomeService _homeService;

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, HomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        [HttpGet("GetAllEmployees")]
        public List<Employee> GetAllEmployees()
        {
            return _homeService.GetAllEmployees();
        }

        [HttpGet("GetEmployeeById/{employeeId}")]
        public IActionResult GetEmployeeById(int employeeId)
        {
            var response = _homeService.GetEmployeeById(employeeId);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpGet("GetActiveEmployees")]
        [ProducesResponseType(typeof(List<Employee>),200)]
        [ProducesResponseType(typeof(NotFoundResult),404)]
        public IActionResult GetActiveEmployees()
        {
            var response = _homeService.GetAllActiveEmployees();
            if(!response.Any())
                return NotFound();
            
            return Ok(response);
        }
        [HttpGet("GetAllInActiveEmployees")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult GetInActiveEmployees()
        {
            var response = _homeService.GetAllInActiveEmployees();
            if(!response.Any())
                return NotFound();
            return Ok(response);

        }

        [HttpGet("GetEmployees_UsingMethodLinq")]
        [ProducesResponseType(typeof(List<EmployeeSalaryModel>), 200)]
        [ProducesResponseType(404)]

        public IActionResult GetEmployeesUsingMethod_BasedOnN(int numberOfRecords)
        {
            var result = _homeService.GetEmployeesBasedOnN_UsingMethod(numberOfRecords);
            if (!result.Any())
                return NotFound();
            return Ok(result);
        }

        [HttpGet("GetEmployees_UsingQueryLinq")]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public IActionResult GetEmployeesUsingQuery_BasedOnN(int numberOfRecords)
        {
            return Ok( _homeService.GetEmployeesBasedOnN_UsingQuery(numberOfRecords));
        }

        [HttpGet("GetEmployeesSalary_InnerJoin_UsingQueryLinq")]
        [ProducesResponseType(typeof(List<EmployeeSalaryModel>),200)]
        public IActionResult GetEmployeesInnerJoinToSalary_UsingQuery_BasedOnN(int numberOfRecords)
        {
            return Ok(_homeService.GetEmployeesInnerJoinToSalary_UsingQuery(numberOfRecords));
        }

        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(List<EmployeeSalaryModel>), 200)]
        [HttpGet("GetEmployeesSalary_InnerJoin_UsingMethodLinq")]
        public IActionResult GetEmployeesInnerJoinToSalary_UsingMethod_BasedOnN(int numberOfRecords)
        {
            return Ok(_homeService.GetEmployeesInnerJoinToSalary_UsingMethod(numberOfRecords));
        }

        [HttpGet("GetEmployeeSalary/{highSalary}")]
        [ProducesResponseType(typeof(EmployeeSalaryModel), 200)]
        public IActionResult GetEmployeeSalary(bool highSalary = true)
        {
            return Ok(_homeService.GetHighestAndLowestSalaryOfEmployee(highSalary));
        }

        [HttpGet("GetTotalSalaryDistributedToEmployee_SumFunction")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult GetTotalSalaryDistributedToEmployee()
        {
            return Ok(_homeService.GetTotalSalaryDistributedToEmployee());
        }

        [HttpGet("LeftJoin_EmployeeSalary_UsingQueryLinq")]
        [ProducesResponseType(typeof(List<EmployeeSalaryModel>),200)]
        public IActionResult GetLeftJoinEmployeeSalary_UsingQueryLinq()
        {
            return Ok(_homeService.LeftJoin_UsingQuery());
        }

        [HttpGet("LeftJoin_EmployeeSalary_UsingMethodLinq")]
        [ProducesResponseType(typeof(List<EmployeeSalaryModel>), 200)]
        public IActionResult GetLeftJoinEmployeeSalary_UsingMethodLinq()
        {
            return Ok(_homeService.LeftJoin_UsingMethod());
        }

        [HttpGet("GetPhoneNumberOfEmployee_UsingSelectMany/{employeeId}")]
        [ProducesResponseType(typeof(List<EmployeeSalaryModel>), 200)]
        public IActionResult GetPhoneNumberOfEmployee_UsingSelectMany(int employeeId)
        {
            return Ok(_homeService.GetPhoneNumbers_UsingSelectMany(employeeId));
        }
        
    }
}
