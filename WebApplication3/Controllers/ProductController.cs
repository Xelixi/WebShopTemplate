using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Singleproduct()
        {
            ViewBag.Message = "Your product page.";
            
            return View();
        }
        public ActionResult Browseproduct()
        {
            ViewBag.Message = "Your browseproduct page.";
            
            return View();
        }
        public ActionResult Productshowcase()
        {
            ViewBag.Message = "Your Productshowcase page.";
            int id = 1;
            var product = new ProductModels(id);
            return View(product);
        }
    }
}