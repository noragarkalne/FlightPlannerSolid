using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Services;
using Flight_Planner.Models;

namespace Flight_Planner.Controllers
{
    public class CustomerController : BasicApiController
    {
        public CustomerController(IFlightService flightService, IMapper mapper)
            : base(flightService, mapper)
        {
        }

        [HttpGet, Route("api/airports")]
        public async Task<IHttpActionResult> Search(string search)
        {
            search = search ?? string.Empty;
            var result = await _flightService.SearchByIncompletePhrases(search);
            return Ok(_mapper.Map(result, new List<AirportResponse>()));
        }

        [HttpGet, Route("api/flights/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var flight = await _flightService.GetFlight(id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(flight, new FlightResponse()));
        }

        [HttpPost, Route("api/flights/search")]
        public async Task<IHttpActionResult> Flights(SearchFlightsRequest req)
        {
            if (SearchFlightsRequest.IsRequestValid(req) == false)
            {
                return BadRequest();
            }

            var result = new PageResult();
            var mapped = _mapper.Map<FlightSearch>(req);
            var matching =  await _flightService.SearchFlights(mapped);
            var enumerable = matching.ToList();

            if (enumerable.Any())
            {
                result.Items.AddRange(enumerable.ToList()); 
                result.TotalItems = enumerable.Count;
            }

            return Ok(result);
        }
    }
}
