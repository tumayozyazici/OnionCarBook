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
    public class GetBlogByMaxBlogCommentQueryHandler :IRequestHandler<GetBlogByMaxBlogCommentQuery, GetBlogByMaxBlogCommentQueryResult>
    {
        private IStatisticRepository _statisticRepository;

        public GetBlogByMaxBlogCommentQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetBlogByMaxBlogCommentQueryResult> Handle(GetBlogByMaxBlogCommentQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticRepository.GetBlogByMaxBlogComment();
            return new GetBlogByMaxBlogCommentQueryResult { BlogByMaxComment = value };
        }
    }
}
