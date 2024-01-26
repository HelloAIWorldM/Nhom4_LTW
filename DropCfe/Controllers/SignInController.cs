using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropCfe.Models;
namespace DropCfe.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
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
        public ActionResult Index(TaiKhoan x)
        {
            taiKhoanTV tk = x.SignIn();
                bool isAuthentic = tk != null && tk.taiKhoan.Equals(x.taiKhoan.ToLower().Trim()) && tk.matKhau.Equals(x.matKhau);
                      if (isAuthentic)
                        {
                            Session["user"] = tk.taiKhoan;
                            Session["dangnhap"] = tk;
                            return RedirectToAction("Index", "Home");
                        }
            
            return View();
        }
    }
}