﻿using AutoMapper;
using MediatR;
using WebJourneys.Application.Contracts;
using WebJourneys.Application.Dtos;

namespace WebJourneys.Application.CQRS.MediatorFlight.Queries
{
    public class GetAllFlightsWithOriginQuery : IRequest<List<FlightResponse>>
    {
        public string Origin { get; set; }
    }

    public class GetAllFlightsWithOriginHandler : IRequestHandler<GetAllFlightsWithOriginQuery, List<FlightResponse>>
    {
        private readonly IFlightRepository _repository;
        private readonly IMapper _mapper;

        public GetAllFlightsWithOriginHandler(IFlightRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<FlightResponse>> Handle(GetAllFlightsWithOriginQuery request, CancellationToken cancellationToken)
        {
            var flights = await _repository.GetAllFlightsWithOrigin(request.Origin.ToUpper());
            var flightsDto = _mapper.Map<List<FlightResponse>>(flights);
            return flightsDto;
        }
    }
}
