﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDomain
{
    public class CarClass
    {
        public int CarClassID { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
