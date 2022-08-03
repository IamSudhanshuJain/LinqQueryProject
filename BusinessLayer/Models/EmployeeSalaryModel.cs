using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class EmployeeSalaryModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }    
        public int? Salary { get; set; }
        public string EmployeeStatus { get; set; }  
    }
}
