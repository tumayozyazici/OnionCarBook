using MediatR;
using OnionCarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using OnionCarBook.Application.Interfaces.CarFeatureInterfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarIdCommandHandler : IRequestHandler<CreateCarFeatureByCarIdCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateCarFeatureByCarIdCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureByCarIdCommand request, CancellationToken cancellationToken)
        {
            await _carFeatureRepository.CreateCarFeatureByCarIdAsync(new CarFeature
            {
                Available = false,
                CarID = request.CarID,
                FeatureID = request.FeatureID,
            });
        }
    }
}
