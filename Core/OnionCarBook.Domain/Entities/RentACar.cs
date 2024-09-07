using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Domain.Entities
{
    public class RentACar
    {
        public int RentACarID { get; set; }
        public int LocationID { get; set; }
        public int CarID { get; set; }
        public bool IsAvailable { get; set; }


        //Nav Props
        public Car Car { get; set; }
        public Location Location { get; set; }
    }
}
