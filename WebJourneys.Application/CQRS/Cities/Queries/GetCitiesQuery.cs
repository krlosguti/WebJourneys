using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.Contracts;
using WebJourneys.Application.CQRS.MediatorFlight.Queries;
using WebJourneys.Application.Dtos;

namespace WebJourneys.Application.CQRS.Cities.Queries
{
    public class GetCitiesQuery: IRequest<List<City>>
    {

    }

    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<City>>
    {
        private readonly IIATARepository _repository;
        private readonly IMapper _mapper;

        public GetCitiesQueryHandler(IIATARepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<City>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _repository.GetAllAvailable();
            var citiesDto = _mapper.Map<List<City>>(cities);
            return citiesDto;
        }
    }
}
