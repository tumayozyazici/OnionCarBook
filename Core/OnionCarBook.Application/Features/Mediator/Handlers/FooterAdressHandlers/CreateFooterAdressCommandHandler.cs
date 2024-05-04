using MediatR;
using OnionCarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.FooterAdresss.Mediator.Handlers.FooterAdressHandlers
{
    public class CreateFooterAdressCommandHandler:IRequestHandler<CreateFooterAdressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public CreateFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAdress
            {
                Description = request.Description,
                Adress = request.Adress,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            });
        }
    }
}
