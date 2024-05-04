﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Domain.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }

        public string Name { get; set; }


        //Nav Props
        public List<Car> Cars { get; set; }
    }
}
