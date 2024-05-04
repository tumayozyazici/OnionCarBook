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

namespace OnionCarBook.Application.FooterAdresss.Mediator.Handlers.FooterAdressHandlers
{
    public class GetFooterAdressByIdQueryHandler : IRequestHandler<GetFooterAdressByIdQuery, GetFooterAdressByIdQueryResult>
    {
        private readonly IRepository<FooterAdress> _repository;

        public GetFooterAdressByIdQueryHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAdressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAdressByIdQueryResult
            {
                FooterAdressID = values.FooterAdressID,
                PhoneNumber = values.PhoneNumber,
                Email = values.Email,
                Adress = values.Adress,
                Description = values.Description
            };
        }
    }
}
