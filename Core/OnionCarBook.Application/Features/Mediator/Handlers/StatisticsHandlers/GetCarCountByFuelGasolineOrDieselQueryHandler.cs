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
    public class GetCarCountByFuelGasolineOrDieselQueryHandler:IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetCarCountByFuelGasolineOrDieselQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountByFuelGasolineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountByFuelGasolineOrDiesel();
            return new GetCarCountByFuelGasolineOrDieselQueryResult { CarCountByFuelGasolineOrDiesel = value };
        }
    }
}