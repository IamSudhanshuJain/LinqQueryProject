using System;

namespace DataLayer.Models
{
    public class Employee : Base
    {
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public Status Status { get; set; }

    }
}
