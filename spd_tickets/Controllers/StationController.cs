using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace spd_tickets.Controllers
{
    public class StationController : Controller
    {
        // GET: Station
        [HttpPost]
        public string Verification(string UUID)
        {
            string response = "false";
            return response;
        }
    }
}