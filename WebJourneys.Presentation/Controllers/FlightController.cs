using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebJourneys.Application.CQRS.MediatorFlight.Commands;
using WebJourneys.Application.CQRS.MediatorFlight.Queries;
using WebJourneys.Application.Dtos;
using WebJourneys.Domain.Models;

namespace WebJourneys.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{origin}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<FlightResponse>> GetFlighsWithOrigin([FromRoute]string origin)
        {
            return _mediator.Send(new GetAllFlightsWithOriginQuery { Origin = origin });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<FlightResponse>> GetFlights()
        {
            return _mediator.Send(new GetAllFlightsQuery());
        }

        [HttpGet("{origin}/{destination}/{coin}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<Journey>> GetJourney([FromRoute] string origin, string destination, string coin)
        {
            return _mediator.Send(new GetJourneyQuery{ Origin = origin, Destination = destination, Coin = coin });
        }

        [HttpPost]
        public Task<FlightResponse> CreateFlight([FromBody] CreateFlightCommand newFlight)
        {
            return _mediator.Send(newFlight);
        }
    }
}
