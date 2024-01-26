using DropCfe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropCfe.Controllers
{
    public class KhoController : Controller
    {
        private static DripCofeEntities db = new DripCofeEntities();
        // GET: VungBaoMat/DanhSachSP
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Xoa(string maSP)
        {
            sanPham a = db.sanPhams.Find(maSP);
            db.sanPhams.Remove(a);
            db.SaveChanges();
            List<sanPham> sanPhams = db.sanPhams.OrderBy(z => z.tenSP).ToList();
            ViewData["danhSachSp"] = sanPhams;
            return RedirectToAction("Index", "DanhSachSP");
        }
        [HttpPost]
        public ActionResult Thongtin(string maSPs)
        {
            sanPham sanPham = db.sanPhams.Find(maSPs);
            List<sanPham> phams = db.sanPhams.OrderBy(z => z.tenSP).ToList();
            ViewData["ThongTin"] = phams;
            return RedirectToAction("Index", "ThongTinSP", sanPham);
        }
    }
}