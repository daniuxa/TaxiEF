using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDomain
{
    public class WorkShift
    {
        //Key
        public int DriverID { get; set; }
        public Driver Driver { get; set; }
        public int NumberWorkShift { get; set; }

        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int AmountOrders { get; set; }
        public float EarnMoney { get; set; }
    }
}
