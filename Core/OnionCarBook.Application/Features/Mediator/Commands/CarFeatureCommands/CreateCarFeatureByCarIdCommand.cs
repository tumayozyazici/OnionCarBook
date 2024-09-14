using MediatR;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarIdCommand :IRequest
    {
        public bool Available { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
    }
}
