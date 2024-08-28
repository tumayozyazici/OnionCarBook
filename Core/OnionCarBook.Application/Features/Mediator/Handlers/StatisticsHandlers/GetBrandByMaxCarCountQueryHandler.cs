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
    public class GetBrandByMaxCarCountQueryHandler :IRequestHandler<GetBrandByMaxCarCountQuery, GetBrandByMaxCarCountQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetBrandByMaxCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBrandByMaxCarCountQueryResult> Handle(GetBrandByMaxCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetBrandByMaxCarCount();
            return new GetBrandByMaxCarCountQueryResult { BrandByMaxCarCount = value };
        }
    }
}
