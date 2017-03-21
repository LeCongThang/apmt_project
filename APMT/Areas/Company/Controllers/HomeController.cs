using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APMT.Areas.Company.Controllers
{
    public class HomeController : Controller
    {
        // GET: Company/Home
        public ActionResult Index()
        {
            return View();
        }

    }
}