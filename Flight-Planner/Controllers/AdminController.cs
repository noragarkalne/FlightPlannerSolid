using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Flight_Planner.Attributes;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Models;

namespace Flight_Planner.Controllers
{
    [BasicAuthentification, EnableCors("*", "*", "*")]
    public class AdminController : BasicApiController
    {
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

            return Ok(flights.Select(f => _mapper.Map<FlightResponse>(f)).ToList());
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
            var task = await _flightService.DeleteFlight(id);

            if (task.Id == id)
            {
                return Ok();
            }

            if (!task.Succeeded)
            {
                return NotFound();
            }

            return Ok();

        }
    }
}
