using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionCarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using OnionCarBook.Application.Features.Mediator.Queries.FooterAdressQueries;

namespace OnionCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAdressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAdress(int id)
        {
            var values = await _mediator.Send(new GetFooterAdressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAdress(CreateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Bilgisi Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Bilgisi Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAdress(int id)
        {
            await _mediator.Send(new RemoveFooterAdressCommand(id));
            return Ok("Alt Adres Bilgisi Silindi");
        }
    }
}
