﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner_Data;
using Microsoft.Ajax.Utilities;


namespace Flight_Planner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return await Query().ToListAsync();
        }

        public async Task<Flight> GetFlight(int id)
        {
            return await GetById<Flight>(id);
        }

        public async Task<ServiceResult> AddFlights(Flight flight)
        {
            var flights = await _ctx.Flights.ToListAsync();

            if (flights.Any(f => f.Equals(flight)))
            {
                return new ServiceResult(false);
            }

            return Create(flight);
        }

        public void ClearFlights()
        {
            _ctx.Flights.RemoveRange(_ctx.Flights);
            _ctx.Airports.RemoveRange(_ctx.Airports);
            _ctx.SaveChanges();
        }

        public async Task<ServiceResult> DeleteFlight(int id)
        {
            var flights = await _ctx.Flights.ToListAsync();
            var flight = flights.SingleOrDefault(f => f.Id.Equals(id));

            if (flight == null)
            {
                return new ServiceResult(id, false);
            }

            return Delete(flight);
        }


        public bool IsFlightValid(Flight flight)
        {
            if (flight == null)
            {
                return false;
            }

            if (flight.To != null &&
                flight.From != null &&
                !string.IsNullOrEmpty(flight.To.Country) &&
                !string.IsNullOrEmpty(flight.To.City) &&
                !string.IsNullOrEmpty(flight.To.AirportCode) &&
                !string.IsNullOrEmpty(flight.From.Country) &&
                !string.IsNullOrEmpty(flight.From.City) &&
                !string.IsNullOrEmpty(flight.From.AirportCode) &&
                !string.IsNullOrEmpty(flight.Carrier) &&
                !string.IsNullOrEmpty(flight.DepartureTime) &&
                !string.IsNullOrEmpty(flight.ArrivalTime) &&
                Convert.ToDateTime(flight.DepartureTime) < Convert.ToDateTime(flight.ArrivalTime))
            {
                return true;
            }

            return false;
        }

        public bool IsAirportValid(Flight flight)
        {
            if (flight == null)
            {
                return false;
            }

            if (!flight.To.AirportCode.ToLower().Trim().Equals(flight.From.AirportCode.ToLower().Trim()) &&
                !flight.To.Equals(flight.From))
            {
                return true;
            }

            return false;
        }

        public async Task<HashSet<Airport>> SearchByIncompletePhrases(string search)
        {
            
            var airports =  _ctx.Airports.Where(x => x.Country.ToString().ToLower().Contains(search.ToLower().Trim()) ||
                                              x.City.ToString().ToLower().Contains(search.ToLower().Trim()) ||
                                              x.AirportCode.ToString().ToLower().Contains(search.ToLower().Trim()))
                .ToList();

            var result = airports.ToHashSet();
            return result;
        }

        public async Task<IEnumerable<Flight>> SearchFlights(FlightSearch req)
        {
            var matchingFlights = await _ctx.Flights.Where(f => f.To.AirportCode.ToLower() == req.To.ToLower() &&
                                                                f.From.AirportCode.ToLower() == req.From.ToLower() &&
                                                                f.DepartureTime.Contains(req.DepartureDate))
                .ToListAsync();
            return matchingFlights.DistinctBy(f => new
            {
                f.DepartureTime, f.ArrivalTime
                , f.Carrier, f.To.City, f.To.AirportCode, f.To.Country
            }).ToList();
        }
    }
}
