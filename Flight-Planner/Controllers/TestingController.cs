using System.Web.Http;
using AutoMapper;
using Flight_Planner.Core.Services;


namespace Flight_Planner.Controllers
{
    [Route("testing-api")]
    public class TestingController : BasicApiController
    {
        public TestingController(IFlightService flightService, IMapper mapper) : base(flightService, mapper)
        {
        }

        [HttpPost, Route("testing-api/clear")]
        public IHttpActionResult Clear()
        {
            _flightService.ClearFlights();
            return Ok();
        }
    }
}
