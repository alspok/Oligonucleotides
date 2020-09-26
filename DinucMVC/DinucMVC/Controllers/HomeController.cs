using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

//namespace DinucMVCMono.Controllers
namespace DinucMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            //ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            //ViewData["Runtime"] = isMono ? "Mono" : ".NET";
            ViewBag.SeqCorrect = "true";

            return View("~/Views/Home/SeqInput.cshtml");
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contacts()
        {

            return View();
        }

    }
}
