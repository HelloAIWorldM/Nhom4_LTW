using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropCfe.Models;
namespace DropCfe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
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
            taiKhoanTV a = (taiKhoanTV)Session["dangnhap"];
            if (a == null)
            {
                Response.Redirect("~/SignIn");
            }
            return View();
        }

    }
}