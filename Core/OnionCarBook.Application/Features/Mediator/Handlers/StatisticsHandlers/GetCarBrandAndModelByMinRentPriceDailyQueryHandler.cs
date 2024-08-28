using MediatR;
using OnionCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using OnionCarBook.Application.Features.Mediator.Results.StatisticsResults;
using OnionCarBook.Application.Interfaces.StatisticInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarBrandAndModelByMinRentPriceDailyQueryHandler:IRequestHandler<GetCarBrandAndModelByMinRentPriceDailyQuery, GetCarBrandAndModelByMinRentPriceDailyQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetCarBrandAndModelByMinRentPriceDailyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarBrandAndModelByMinRentPriceDailyQueryResult> Handle(GetCarBrandAndModelByMinRentPriceDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarBrandAndModelByMinRentPriceDaily();
            return new GetCarBrandAndModelByMinRentPriceDailyQueryResult { CarBrandAndModelByMinRentPriceDaily = value };
        }
    }
}
