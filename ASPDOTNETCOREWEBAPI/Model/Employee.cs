using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDOTNETCOREWEBAPI.Model
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }

        
    }
}
