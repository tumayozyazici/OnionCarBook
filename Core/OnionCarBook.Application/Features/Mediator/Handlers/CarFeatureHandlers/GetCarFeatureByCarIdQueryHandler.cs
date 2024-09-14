using MediatR;
using OnionCarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using OnionCarBook.Application.Features.Mediator.Results.CarFeatureResults;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Application.Interfaces.CarFeatureInterfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _carFeatureRepository.GetCarFeaturesByCarIdAsync(request.Id);
            return values.Select(x=> new GetCarFeatureByCarIdQueryResult
            {
                CarID = request.Id,
                Available = x.Available,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName=x.Feature.Name
            }).ToList();
        }
    }
}
