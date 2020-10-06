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
        public async Task<IHttpActionResult> Search(string searchedPhrase)
        {

            var result = await _flightService.SearchByIncompletePhrases(searchedPhrase);
            return Ok(_mapper.Map(result, new AirportResponse()));
        }

        [HttpGet, Route("flights/{id}")]
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
        public async Task<IHttpActionResult> Flights(SearchFlightRequest req)
        {
            if (SearchFlightRequest.IsRequestValid(req) == false)
            {
                return BadRequest();
            }

            var result = new PageResult();
            var flights = await _flightService.GetFlights();

            foreach (var f in flights)
            {
                if (SearchFlightRequest.IsRequestValid(req)) //FlightStorage.IsSearchValid(req) &&
                {
                    result.Items.Add(f);
                    result.TotalItems++;
                }
            }
            return Ok(result);
        }
    }
}
