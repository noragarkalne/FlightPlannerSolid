﻿using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Models;

namespace Flight_Planner
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AirportRequest, Airport>()
                    .ForMember(d => d.Id,
                        n => n.Ignore());
                cfg.CreateMap<Airport, AirportRequest>();
                cfg.CreateMap<FlightRequest, Flight>();
                cfg.CreateMap<Flight, FlightRequest>();
                cfg.CreateMap<AirportResponse, AirportRequest>()
                    .ForMember(d => d.Id,
                        o => o.Ignore());
                cfg.CreateMap<AirportRequest, AirportResponse>();
                cfg.CreateMap<FlightRequest, FlightResponse>();
                cfg.CreateMap<Airport, AirportResponse>();
                cfg.CreateMap<AirportResponse, Airport>()
                    .ForMember(m => m.Id, 
                        o => o.Ignore());
                cfg.CreateMap<Flight, FlightResponse>();
                cfg.CreateMap<SearchFlightsRequest, FlightSearch>();
                cfg.CreateMap<FlightSearch,SearchFlightsRequest>();
            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}