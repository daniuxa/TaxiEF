using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDomain
{
    public class RatingComment
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public float Rating { get; set; }
        public string Comment { get; set; }
    }
}
