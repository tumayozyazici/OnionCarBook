using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Commands.FooterAdressCommands
{
    public class UpdateFooterAdressCommand :IRequest
    {
        public int FooterAdressID { get; set; }

        public string Description { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
