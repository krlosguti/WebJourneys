using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.Contracts;
using WebJourneys.Application.Dtos;
using WebJourneys.Domain.Models;

namespace WebJourneys.Application.CQRS.MediatorFlight.Commands
{
    public class CreateFlightCommand : IRequest<FlightResponse>
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public int TransportId { get; set; }
    }

    public class CreateFlightValidator: AbstractValidator<CreateFlightCommand>
    {
        public CreateFlightValidator() 
        {
            RuleFor(x => x.Origin).NotEmpty().Length(3);
            RuleFor(x => x.Destination).NotEmpty().Length(3);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.TransportId).GreaterThan(0);
        }
    }

    public class CreateFlightCommandHandler: IRequestHandler<CreateFlightCommand, FlightResponse>
    {
        private readonly IFlightRepository _repository;
        private readonly IMapper _mapper;
        public CreateFlightCommandHandler(IFlightRepository repository, IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FlightResponse> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var fligth = _mapper.Map<Flight>(request);
            var flightr = await _repository.AddAsync(fligth);
            var flightResponse = _mapper.Map<FlightResponse>(flightr);
            return flightResponse;
        }
    }
}
