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
    public class GetCountOfAutomaticCarsQueryHandler:IRequestHandler<GetCountOfAutomaticCarsQuery, GetCountOfAutomaticCarsQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetCountOfAutomaticCarsQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCountOfAutomaticCarsQueryResult> Handle(GetCountOfAutomaticCarsQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCountOfAutomaticCars();
            return new GetCountOfAutomaticCarsQueryResult { CountOfAutomaticCars = value };
        }
    }
}
