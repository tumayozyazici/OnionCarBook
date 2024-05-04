using OnionCarBook.Application.Features.CQRS.Commands.CarCommands;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            value.Fuel = command.Fuel;
            value.Seat = command.Seat;
            value.BigImageUrl = command.BigImageUrl;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Luggage = command.Luggage;
            value.Km = command.Km;
            value.Model = command.Model;
            value.BrandID = command.BrandID;
            value.Transmission = command.Transmission;
            await _repository.UpdateAsync(value);
        }
    }
}
