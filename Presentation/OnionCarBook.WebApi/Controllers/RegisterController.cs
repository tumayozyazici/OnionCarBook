using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionCarBook.Application.Features.Mediator.Commands.RegisterAppUserCommands;

namespace OnionCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kullanıcı başarıyla oluşturuldu");
        }
    }
}