﻿using OnionCarBook.Application.InterfaceDtos;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Interfaces.CarPricingInterfaces
{
	public interface ICarPricingRepository
	{
		List<CarPricing> GetCarPricingWithCars();
		List<CarPricingInterfaceDto> GetCarPricingWithTimePeriod();
	}
}
