using MediatR;
using OnionCarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using OnionCarBook.Application.Features.Mediator.Results.FooterAdressResults;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class GetFooterAdressQueryHandler : IRequestHandler<GetFooterAdressQuery, List<GetFooterAdressQueryResult>>
    {
        private readonly IRepository<FooterAdress> _repository;

        public GetFooterAdressQueryHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAdressQueryResult>> Handle(GetFooterAdressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetFooterAdressQueryResult
            {
                Adress=x.Adress,
                Description=x.Description,
                Email=x.Email,
                FooterAdressID=x.FooterAdressID,
                PhoneNumber=x.PhoneNumber
            }).ToList();
        }
    }
}
