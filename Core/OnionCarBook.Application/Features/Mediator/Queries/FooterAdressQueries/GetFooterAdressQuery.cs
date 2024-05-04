using MediatR;
using OnionCarBook.Application.Features.Mediator.Results.FooterAdressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Queries.FooterAdressQueries
{
    public class GetFooterAdressQuery:IRequest<List<GetFooterAdressQueryResult>>
    {

    }
}
