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
    public class GetAvgRentPriceForWeeklyQueryHandler:IRequestHandler<GetAvgRentPriceForWeeklyQuery, GetAvgRentPriceForWeeklyQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetAvgRentPriceForWeeklyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAvgRentPriceForWeeklyQueryResult> Handle(GetAvgRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetAvgRentPriceForWeekly();
            return new GetAvgRentPriceForWeeklyQueryResult { AvgPriceForWeekly = value };
        }
    }
}
