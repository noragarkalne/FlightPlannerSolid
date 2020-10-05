using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Flight_Planner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        //// GET: api/Home
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Home/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Home
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Home/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Home/5
        //public void Delete(int id)
        //{
        //}
    }
}
