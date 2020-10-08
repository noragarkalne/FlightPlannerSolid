using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Models;
using Flight_Planner.Services;
using Newtonsoft.Json.Linq;

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
            
            if (SearchFlightsRequest.IsRequestValid(req) == false) //novalideeju vai nav null un vai pats req der
            {
                return BadRequest();
            } //ja neder viss beidzas te

            var result = new PageResult();
            var x = _mapper.Map<FlightSearch>(req); //nomapoju
            var matching =  await _flightService.SearchFlights(x);

            var enumerable = matching.ToList();
            if (enumerable.Any()) //parbaudu vai tads jau ir 
            {
                result.Items.AddRange(enumerable.ToList()); //ja ir pievienoju pieprasito 
                result.TotalItems = enumerable.Count; // palielinu skaitu
            }

            return Ok(result); // atdodu atpakal page result.
        }
    }
}
