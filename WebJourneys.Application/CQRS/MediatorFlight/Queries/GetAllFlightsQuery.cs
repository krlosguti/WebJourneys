using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.Contracts;
using WebJourneys.Application.Dtos;

namespace WebJourneys.Application.CQRS.MediatorFlight.Queries
{
    public class GetAllFlightsQuery : IRequest<List<FlightResponse>>
    {
        string coin { get; set; } = "USD";
    }

    public class GetAllFlightsQueryHandler : IRequestHandler<GetAllFlightsQuery, List<FlightResponse>>
    {
        private readonly IFlightRepository _repository;
        private readonly IMapper _mapper;

        public GetAllFlightsQueryHandler(IFlightRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<FlightResponse>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _repository.GetAllAsync();
            var flightsDto = _mapper.Map<List<FlightResponse>>(flights);
            return flightsDto;
        }
    }
}
