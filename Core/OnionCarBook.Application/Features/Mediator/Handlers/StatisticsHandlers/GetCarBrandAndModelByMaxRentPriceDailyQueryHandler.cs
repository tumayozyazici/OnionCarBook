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
    public class GetCarBrandAndModelByMaxRentPriceDailyQueryHandler:IRequestHandler<GetCarBrandAndModelByMaxRentPriceDailyQuery, GetCarBrandAndModelByMaxRentPriceDailyQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetCarBrandAndModelByMaxRentPriceDailyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarBrandAndModelByMaxRentPriceDailyQueryResult> Handle(GetCarBrandAndModelByMaxRentPriceDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarBrandAndModelByMaxRentPriceDaily();
            return new GetCarBrandAndModelByMaxRentPriceDailyQueryResult { CarBrandAndModelByMaxRentPriceDaily = value };
        }
    }
}
