using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Util;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserDTO user = (UserDTO)Session["User"];

            if (user != null)
            {
                return RedirectToAction("Index", "Tournament");
            }
            UserDTO restoredUser = CookiesAuthenticationWorker.RestoreFromCookies(Request);

            if (restoredUser != null)
            {
                Session["User"] = restoredUser;
                return RedirectToAction("Index", "Tournaments");
            }

            return RedirectToAction("Index", "About");
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