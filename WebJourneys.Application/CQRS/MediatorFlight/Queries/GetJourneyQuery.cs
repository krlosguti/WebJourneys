using AutoMapper;
using MediatR;
using Newtonsoft.Json.Linq;
using WebJourneys.Application.Contracts;
using WebJourneys.Application.Dtos;

namespace WebJourneys.Application.CQRS.MediatorFlight.Queries
{
    public class GetJourneyQuery : IRequest<List<Journey>>
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Coin { get; set; }
    }

    public class GetJourneyQueryHandler : IRequestHandler<GetJourneyQuery, List<Journey>>
    {
        private readonly IFlightRepository _repository;
        private readonly IMapper _mapper;

        public GetJourneyQueryHandler(IFlightRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private async Task<double> ExchangeRate(string Coin, double Price)
        {
            //Recovering exchange
            using (var httpClient = new HttpClient())
            {
                var address = $"https://v6.exchangerate-api.com/v6/b033f9c3c2db55cc0858d44e/pair/USD/{Coin}/{Price}";
                using (var response = await httpClient.GetAsync(address))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(apiResponse);
                        return (double)json["conversion_result"];
                    }
                }
            }
            return 0;
        }
        public async Task<List<Journey>> Handle(GetJourneyQuery request, CancellationToken cancellationToken)
        {
            var journeys = new List<Journey>();
            var getJourneys = await _repository.GetAllFlights(request.Origin, request.Destination);

            foreach(var j in getJourneys) 
            {
                var newJourney = new Journey();
                newJourney.Origin = request.Origin;
                newJourney.Destination = request.Destination;
                newJourney.Coin = request.Coin;
                newJourney.Flights = _mapper.Map<List<FlightResponse>>(j);
                newJourney.Price = 0;
                foreach (var f in newJourney.Flights)
                {
                    f.Coin = request.Coin;
                    f.PriceCoin = await ExchangeRate(request.Coin, f.Price);
                    newJourney.Price += f.PriceCoin;
                }
                journeys.Add(newJourney);
            }
            
            return journeys;
        }
    }
}
