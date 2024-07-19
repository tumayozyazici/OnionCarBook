using MediatR;
using OnionCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using OnionCarBook.Application.Features.Mediator.Queries.LocationQueries;
using OnionCarBook.Application.Features.Mediator.Results.CarPricingResults;
using OnionCarBook.Application.Features.Mediator.Results.LocationResults;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Application.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
	{
		private readonly ICarPricingRepository _carPricingRepository;

		public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
		{
			_carPricingRepository = carPricingRepository;
		}

		public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
		{
			var values = _carPricingRepository.GetCarPricingWithCars();
			return values.Select(x => new GetCarPricingWithCarQueryResult
			{
				Amount = x.Amount,
				Brand=x.Car.Brand.Name,
				CarPricingId = x.CarPricingID,
				CoverImageUrl = x.Car.CoverImageUrl,
				Model=x.Car.Model
			}).ToList();
		}
	}
}
