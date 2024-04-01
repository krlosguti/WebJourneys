using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebJourneys.Application.CQRS.Cities.Queries;
using WebJourneys.Application.CQRS.MediatorFlight.Queries;
using WebJourneys.Application.Dtos;

namespace WebJourneys.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IATAController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<City>> GetCities()
        {
            return _mediator.Send(new GetCitiesQuery());
        }
    }
}
