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
    public class GetCarCountBelow1000KmQueryHandler:IRequestHandler<GetCarCountBelow1000KmQuery, GetCarCountBelow1000KmQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetCarCountBelow1000KmQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountBelow1000KmQueryResult> Handle(GetCarCountBelow1000KmQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetCarCountBelow1000Km();
            return new GetCarCountBelow1000KmQueryResult { CarCountBelow1000Km = value };
        }
    }
}
