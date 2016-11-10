using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About pagina";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact pagina";

            return View();
        }
    }
}