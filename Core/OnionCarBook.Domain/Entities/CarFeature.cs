﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Domain.Entities
{
    public class CarFeature
    {
        public int CarFeatureID { get; set; }

        public bool Available { get; set; }


        //Nav Props
        public int CarID { get; set; }

        public Car Car { get; set; }

        public Feature Feature { get; set; }

        public int FeatureID { get; set; }
    }
}
