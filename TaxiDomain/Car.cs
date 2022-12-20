using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDomain
{
    public class Car
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string VIN { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProdYear { get; set; }

        public int CarClassID { get; set; }
        public CarClass CarClass { get; set; }

        public int Mileage { get; set; }
        public DateTime LastDateMaintenance { get; set; }
        public string LicensePlate { get; set; }

        public int CarTypeID { get; set; }
        public CarType CarType { get; set; }

        public int ChildSeat { get; set; }

        public List<Driver> Drivers { get; set; } = new List<Driver>();
    }
}
