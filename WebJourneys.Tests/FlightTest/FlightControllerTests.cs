using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.CQRS.MediatorFlight.Commands;
using WebJourneys.Application.CQRS.MediatorFlight.Queries;
using WebJourneys.Application.Dtos;
using WebJourneys.Presentation.Controllers;

namespace WebJourneys.Tests.FlightTest
{
    public class FlightControllerTests
    {
        [Fact]
        public async Task GetFlighsWithOrigin_Returns_OkObjectResult()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var origin = "MZL";
            var expectedFlights = new List<FlightResponse>();
            expectedFlights.Add(
                new FlightResponse
                {
                    Id = 1,
                    Origin = "MZL",
                    Destination = "BOG",
                    Price=1000,
                    TransportId=1,
                    Coin = "USD",
                    PriceCoin = 1000,
                    NameTransport = "AV8080"
                }
            );

            mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllFlightsWithOriginQuery>(), default))
                .ReturnsAsync(expectedFlights);

            var controller = new FlightController(mockMediator.Object);

            // Act
            var actionResult = await controller.GetFlighsWithOrigin(origin);

            // Assert
            var okObjectResult = Assert.IsType<List<FlightResponse>>(actionResult);
            var flights = Assert.IsAssignableFrom<List<FlightResponse>>(okObjectResult);
            Assert.NotEmpty( flights);
        }

        [Fact]
        public async Task GetFlights_Returns_OkObjectResult()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var expectedFlights = new List<FlightResponse>();
            expectedFlights.Add(
                new FlightResponse
                {
                    Id = 1,
                    Origin = "MZL",
                    Destination = "BOG",
                    Price = 1000,
                    TransportId = 1,
                    Coin = "USD",
                    PriceCoin = 1000,
                    NameTransport = "AV8080"
                }
            );

            mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllFlightsQuery>(), default))
                .ReturnsAsync(expectedFlights);

            var controller = new FlightController(mockMediator.Object);

            // Act
            var actionResult = await controller.GetFlights();

            // Assert
            var okObjectResult = Assert.IsType<List<FlightResponse>>(actionResult);
            var flights = Assert.IsAssignableFrom<List<FlightResponse>>(okObjectResult);
            Assert.NotEmpty(flights);
        }

        [Fact]
        public async Task CreateFlight_Returns_OkObjectResult()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var newFlight = new CreateFlightCommand(); // You should provide sample data here
            var expectedFlightResponse = new FlightResponse();
            expectedFlightResponse =
                new FlightResponse
                {
                    Id = 1,
                    Origin = "MZL",
                    Destination = "BOG",
                    Price = 1000,
                    TransportId = 1,
                    Coin = "USD",
                    PriceCoin = 1000,
                    NameTransport = "AV8080"
                };

            mockMediator
                .Setup(m => m.Send(It.IsAny<CreateFlightCommand>(), default))
                .ReturnsAsync(expectedFlightResponse);

            var controller = new FlightController(mockMediator.Object);

            // Act
            var actionResult = await controller.CreateFlight(newFlight);

            // Assert
            var okObjectResult = Assert.IsType<FlightResponse>(actionResult);
            var flightResponse = Assert.IsType<FlightResponse>(okObjectResult);
            Assert.Equal(expectedFlightResponse, flightResponse);
        }
    }
}
