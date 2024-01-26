using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropCfe.Models;
namespace DropCfe.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(taiKhoanTV tk)
        {
            DripCofeEntities data = new DripCofeEntities();
            {
                if (tk.matKhau.Equals(tk.matKhau))
                {
                    data.taiKhoanTVs.Add(tk);
                    data.SaveChanges();
                    if (ModelState.IsValid)
                        ModelState.Clear();
                }
                return RedirectToAction("Index", "SignIn", new { area = "Views" });
            }
        }
    }
}