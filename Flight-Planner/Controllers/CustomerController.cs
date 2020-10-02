using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Controllers;
using Flight_Planner.Core.Services;

namespace FlightPlannerApi.Controllers
{
    public class CustomerController : ApiController
    {

        [HttpGet, Route("api/airports")]
        public IHttpActionResult Airports()
        {

            return Ok();
        }

        //[HttpGet, Route("/flights/{id}")]
        //public async Task<IHttpActionResult> Get(int id)
        //{
        //    var flight = await _flightService.GetById(id);

        //    if (flight == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(flight); //?
        //}

        [HttpPost, Route("api/flights/search")]
        public IHttpActionResult Flights()
        {
            return Ok();
        }
    }
}
