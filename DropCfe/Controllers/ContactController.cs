using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropCfe.Models;
namespace DropCfe.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            GioHang gh = Session["giohang"] as GioHang;
            if (gh == null)
            {
                gh = new GioHang();
                Session["giohang"] = gh;
            }
            ViewData["SP"] = gh;
            return View();
        }
    }
}