using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Flight_Planner.Attributes;
using Flight_Planner.Core.Interfaces;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Models;
using Flight_Planner.Services;
using Flight_Planner_Data;

namespace Flight_Planner.Controllers
{
    [BasicAuthentification]
    public class AdminController : BasicApiController
    {
        //private static object _myObjectList = new object();
        public AdminController(IFlightService flightService, IMapper mapper) 
            : base(flightService, mapper)
        {
        }

        [HttpGet, Route("admin-api/flights/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var flight = await _flightService.GetFlight(id);

            if (flight == null)
            {
                return NotFound();
            }
           
            return Ok(_mapper.Map(flight, new FlightResponse()));
        }

        [HttpGet, Route("admin-api/flights/{id}")]
        public async Task<IHttpActionResult> GetFlights()
        {
            var flights = await _flightService.GetFlights();

            return Ok(
                flights.Select(f => _mapper.Map<FlightResponse>(f)).ToList()); // =ToList
        }

        [HttpPut, Route("admin-api/flights")]
        public async Task<IHttpActionResult> Add(Flight flight)
        {
            
                if (_flightService.IsFlightValid(flight) == false || _flightService.IsAirportValid(flight) == false)
                {
                    return BadRequest();
                }

                var task = await _flightService.AddFlights(flight);


                if (task.Succeeded == false)
                {
                    return Conflict();
                }


                flight.Id = task.Entity.Id;

                return Created("", _mapper.Map<FlightResponse>(flight));
            
        }

        [HttpDelete, Route("admin-api/flights/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flight = await _flightService.GetById(id);

            if (flight != null)
            {
                await _flightService.DeleteFlight(id);
                return Ok();
            }

            if (flight == null)
            {
                return Ok();
            }

            return NotFound();

        }
    }
}
