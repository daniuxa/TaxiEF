using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDomain
{
    public class TaxiDepartment
    {
        public int TaxiDepartmentID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Phone { get; set; }

        public List<Driver> drivers { get; set; } = new List<Driver>();
    }
}
