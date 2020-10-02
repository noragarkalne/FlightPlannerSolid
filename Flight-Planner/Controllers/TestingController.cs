using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace FlightPlannerApi.Controllers
{
    [Route("testing-api")]
    public class TestingController : ApiController
    {
        [HttpPost, Route("testing-api/clear")]
        public IHttpActionResult Clear(HttpRequestMessage message)
        {
            return Ok();
        }
    }
}
