﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Domain.Entities
{
    public class CarDescription
    {
        public int CarDescriptionID { get; set; }
        public string Details { get; set; }


        //Nav Props
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
