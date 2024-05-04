using OnionCarBook.Application.Features.CQRS.Commands.ContactCommands;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ContactID);
            value.Name = command.Name;
            value.Email = command.Email;
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Message = command.Message;
            await _repository.UpdateAsync(value);
        }
    }
}
