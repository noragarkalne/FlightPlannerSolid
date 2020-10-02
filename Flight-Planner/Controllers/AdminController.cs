using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Flight_Planner.Attributes;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner_Data;

namespace Flight_Planner.Controllers
{
    [BasicAuthentification]
    public class AdminController : BasicApiController
    {
        public AdminController(IFlightService flightService, IMapper mapper) 
            : base(flightService, mapper)
        {
        }

        [HttpGet, Route("admin-api/flights/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var flight = await _flightService.GetById(id);

            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }



        [HttpPut, Route("admin-api/flights")]
        public IHttpActionResult Add()
        {
            return Ok();
        }

        [HttpDelete, Route("admin-api/flights/{id}")]
        public IHttpActionResult Delete()
        {
            return Ok();
        }

        
    }
}
