using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDomain
{
    public class Client : Person
    {
        public string Email { get; set; }

        public List<Order> orders = new List<Order>();
    }
}
