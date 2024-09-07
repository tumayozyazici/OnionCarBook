using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using OnionCarBook.Application.InterfaceDtos;
using OnionCarBook.Application.Interfaces.CarPricingInterfaces;
using OnionCarBook.Domain.Entities;
using OnionCarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(x => x.PricingID == 2).ToList();
			return values;
		}

		public List<CarPricingInterfaceDto> GetCarPricingWithTimePeriod()
		{
			List<CarPricingInterfaceDto> values = new List<CarPricingInterfaceDto>();
			using(var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select CoverImageUrl, Model, CarPricings.CarID, PricingID, Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarID Inner Join Brands On Brands.BrandID = Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([1],[2],[3])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read()) 
					{
						CarPricingInterfaceDto carPricing = new CarPricingInterfaceDto()
						{
							Model = reader["Model"].ToString(),
							CoverImageUrl= reader["CoverImageUrl"].ToString(),
							CarID= Convert.ToInt32(reader[2]),
							Amounts = new List<decimal>
							{
								Convert.ToDecimal(reader[3]),
								Convert.ToDecimal(reader[4]),
								Convert.ToDecimal(reader[5]),
							}
						};
						values.Add(carPricing);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}