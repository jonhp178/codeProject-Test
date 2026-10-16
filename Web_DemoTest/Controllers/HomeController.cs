using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_DemoTest.Models;

namespace Web_DemoTest.Controllers
{
    public class HomeController : Controller
    {
        CoffeeOrderDBEntities ad = new CoffeeOrderDBEntities();
        public ActionResult Index()
        {

            return View(ad.AdminUsers.ToList()); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}