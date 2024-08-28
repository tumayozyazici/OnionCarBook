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
    public class GetBrandCountQueryHandler :IRequestHandler<GetBrandCountQuery,GetBrandCountQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetBrandCountQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetBrandCount();
            return new GetBrandCountQueryResult { BrandCount = value };
        }
    }
}
