﻿using MediatR;
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
    public class GetAvgRentPriceForDailyQueryHandler:IRequestHandler<GetAvgRentPriceForDailyQuery,GetAvgRentPriceForDailyQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetAvgRentPriceForDailyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAvgRentPriceForDailyQueryResult> Handle(GetAvgRentPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetAvgRentPriceForDaily();
            return new GetAvgRentPriceForDailyQueryResult { AvgPriceForDaily = value};
        }
    }
}
