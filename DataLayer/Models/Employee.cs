using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Employee : Base
    {
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public Status Status { get; set; }

    }
}
