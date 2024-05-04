using OnionCarBook.Application.Features.CQRS.Commands.AboutCommands;
using OnionCarBook.Application.Features.CQRS.Commands.BannerCommands;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerID);
            value.Description = command.Description;
            value.Title = command.Title;
            value.VideoUrl = command.VideoUrl;
            value.VideoDescription = command.VideoDescription;
            await _repository.UpdateAsync(value);
        }
    }
}
