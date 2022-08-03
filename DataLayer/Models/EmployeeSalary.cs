using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class EmployeeSalary:Base
    {
        public int EmployeeId { get; set; }
        public int Salary { get; set; }
    }
}
