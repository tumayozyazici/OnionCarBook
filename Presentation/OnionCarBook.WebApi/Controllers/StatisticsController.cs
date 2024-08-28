using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionCarBook.Application.Features.Mediator.Queries.StatisticsQueries;

namespace OnionCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var value = await _mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQuery());
            return Ok(value);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var value = await _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var value = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(value);
        }

        [HttpGet("GetCountOfAutomaticCars")]
        public async Task<IActionResult> GetCountOfAutomaticCars()
        {
            var value = await _mediator.Send(new GetCountOfAutomaticCarsQuery());
            return Ok(value);
        }

        [HttpGet("GetBrandByMaxCarCount")]
        public async Task<IActionResult> GetBrandByMaxCarCount()
        {
            var value = await _mediator.Send(new GetBrandByMaxCarCountQuery());
            return Ok(value);
        }

        [HttpGet("GetBlogByMaxBlogComment")]
        public async Task<IActionResult> GetBlogByMaxBlogComment()
        {
            var value = await _mediator.Send(new GetBlogByMaxBlogCommentQuery());
            return Ok(value);
        }

        [HttpGet("GetCarCountBelow1000Km")]
        public async Task<IActionResult> GetCarCountBelow1000Km()
        {
            var value = await _mediator.Send(new GetCarCountBelow1000KmQuery());
            return Ok(value);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var value = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(value);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetLocatiGetCarCountByFuelElectriconCount()
        {
            var value = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(value);
        }

        [HttpGet("GetCarBrandAndModelByMaxRentPriceDaily")]
        public async Task<IActionResult> GetCarBrandAndModelByMaxRentPriceDaily()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByMaxRentPriceDailyQuery());
            return Ok(value);
        }

        [HttpGet("GetCarBrandAndModelByMinRentPriceDaily")]
        public async Task<IActionResult> GetCarBrandAndModelByMinRentPriceDaily()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByMinRentPriceDailyQuery());
            return Ok(value);
        }
    }
}
