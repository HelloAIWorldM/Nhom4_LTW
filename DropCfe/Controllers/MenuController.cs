using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropCfe.Models;
namespace DropCfe.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
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
        public ActionResult themSP(string maSP)
        {
            GioHang gioHang = Session["giohang"] as GioHang;
            if (Session["giohang"] == null)
            {
                gioHang = new GioHang();
                Session["giohang"] = gioHang;
            }
            gioHang.themSP(maSP);
            Session["giohang"] = gioHang;
            return RedirectToAction("Index");
        }

        public ActionResult TangSoLuong(string maSP)
        {
            GioHang gh = Session["giohang"] as GioHang;
            gh.themSP(maSP);
            ViewData["CartItemCount"] = gh.tongSLSP();
            ViewData["SP"] = gh;
            return RedirectToAction("Index");
        }

        public ActionResult GiamSoLuong(string maSP)
        {
            GioHang gh = Session["giohang"] as GioHang;
            gh.giamSP(maSP);
            ViewData["SP"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult XoaItem(string maSP)
        {
            GioHang gh = Session["giohang"] as GioHang;
            gh.xoaSP(maSP);
            ViewData["CartItemCount"] = gh.tongSLSP();
            ViewData["SP"] = gh;
            return RedirectToAction("Index");
        }
    }
}