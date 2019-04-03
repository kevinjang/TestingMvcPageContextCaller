using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingMvcPageContextCallee;

namespace TestingMvcPageContextCaller.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = UserName;

            return Json("{\"UserName\":\""+ UserName + "\"}", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = UserIdentityName;

            return View();
        }

        public ActionResult Authed()
        {
            ViewBag.Message = UserIdentityAuth;
            return View();
        }

        public string UserName
        {
            get { return (new Class1()).GetUserName(); }
        }

        public string UserIdentityName
        {

            get { return HttpContext.User.Identity.Name == ""? "well, it seems that the username is empty": HttpContext.User.Identity.Name; }
        }
        public string UserIdentityAuth
        {

            get { return HttpContext.User.Identity.IsAuthenticated ? "well, it seems you are unauthenticated" : HttpContext.User.Identity.IsAuthenticated.ToString(); }
        }
    }
}