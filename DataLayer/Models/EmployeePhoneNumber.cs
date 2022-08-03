using System.Collections.Generic;

namespace DataLayer.Models
{
    public class EmployeePhoneNumber : Base
    {
        public int EmployeeId { get; set; }
        public IEnumerable<string> PhoneNumbers { get; set; }
    }
}
