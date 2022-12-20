using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDomain
{
    public class Driver
    {
        public int DriverID { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }

        public int TaxiDepartmentID { get; set; }
        public TaxiDepartment TaxiDepartment { get; set; }

        public string CarVIN { get; set; }
        public Car Car { get; set; }

        public float Rating { get; set; }
        public DateTime BirthDate { get; set; }
        public string TaxNumber { get; set; }

        public List<Order> orders { get; set; } = new List<Order>();
    }
}
