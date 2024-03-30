﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJourneys.Application.CQRS.MediatorFlight.Commands;
using WebJourneys.Application.Dtos;
using WebJourneys.Domain.Models;

namespace WebJourneys.Application.MapperConfiguration
{
    public class ModelProfile: Profile
    {
        public ModelProfile() 
        {
            CreateMap<CreateFlightCommand, Flight>().ReverseMap();
            CreateMap<FlightResponse, Flight>().ReverseMap();
        }
    }
}
