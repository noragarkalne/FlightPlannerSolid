using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Controllers;
using Flight_Planner.Core.Services;
using Flight_Planner_Data;


namespace Flight_Planner.Controllers
{
    [Route("testing-api")]
    public class TestingController : BasicApiController
    {
        [HttpPost, Route("testing-api/clear")]
        public IHttpActionResult Clear()
        {
            _flightService.ClearFlights();
            return Ok();
        }

        public TestingController(IFlightService flightService, IMapper mapper) : base(flightService, mapper)
        {
        }
    }
}
