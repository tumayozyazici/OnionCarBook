using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.InterfaceDtos
{
	public class CarPricingInterfaceDto
	{
		public CarPricingInterfaceDto()
		{
			Amounts = new List<decimal>();
		}

		public string Model { get; set; }
		public int CarID { get; set; }
		public string CoverImageUrl { get; set; }
        public List<decimal> Amounts { get; set; }
	}
}