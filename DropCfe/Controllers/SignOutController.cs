using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropCfe.Controllers
{
    public class SignOutController : Controller
    {
        // GET: SignOut
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignOut()
        {
            Session.Remove("user");
            return RedirectToAction("Index", "SignIn");
        }
    }
}