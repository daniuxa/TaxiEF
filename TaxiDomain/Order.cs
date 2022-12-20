using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDomain
{
    public class Order
    {
        public int OrderID { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public string AdressFrom { get; set; }
        public string AdressTo { get; set; }

        public int Mileage { get; set; }

        public int DriverID { get; set; }
        public Driver Driver { get; set; }

        public decimal PriceOfOrder { get; set; }
        public string PaymentMethode { get; set; }
        public DateTime DateTimeOfOrder { get; set; }
        public float DriverPercent { get; set; }
        public string StatusOfOrder { get; set; }

        public List<RatingComment> RatingComments { get; set; } = new List<RatingComment>();
    }
}
