using MediatR;
using OnionCarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers
{
    public class UpdateFooterAdressCommandHandler : IRequestHandler<UpdateFooterAdressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public UpdateFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FooterAdressID);
            values.PhoneNumber = request.PhoneNumber;
            values.Adress = request.Adress;
            values.Email = request.Email;
            values.Description = request.Description;
            await _repository.UpdateAsync(values);
        }
    }
}
