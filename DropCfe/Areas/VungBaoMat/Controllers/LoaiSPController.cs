using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropCfe.Models;
namespace DropCfe.Areas.VungBaoMat.Controllers
{
    public class LoaiSPController : Controller
    {
        private static bool isCapNhat = false;
        // GET: VungBaoMat/LoaiSP
        [HttpGet]
        public ActionResult Index()
        {
            List<loaiSP> loaisp = new DripCofeEntities().loaiSPs.OrderBy(z => z.loaiHang).ToList();
            ViewData["danhsachLoai"] = loaisp;
            return View();
        }
        [HttpPost]
        public ActionResult Index(loaiSP x)
        {
            DripCofeEntities db = new DripCofeEntities();
            if (!isCapNhat)
            {
                db.loaiSPs.Add(x);
            }
            else
            {
                loaiSP y = db.loaiSPs.Find(x.maLoai);
                y.maLoai = x.maLoai;
                y.loaiHang = x.loaiHang;
                y.ghiChu = x.ghiChu;
                isCapNhat = false;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            List<loaiSP> list = db.loaiSPs.OrderBy(z => z.loaiHang).ToList();
            ViewData["danhsachLoai"] = list;
            return View("Index");
        }
        [HttpPost]
        public ActionResult Xoa(string maLoai)
        {
            DripCofeEntities db = new DripCofeEntities();
            loaiSP x = db.loaiSPs.Find(maLoai);
            db.loaiSPs.Remove(x);
            db.SaveChanges();
            List<loaiSP> list =db.loaiSPs.OrderBy(z => z.loaiHang).ToList();
            ViewData["danhsachLoai"] = list;
            return View("Index");
        }
        [HttpPost]
        public ActionResult CapNhat(string maLoaic)
        {
            DripCofeEntities db = new DripCofeEntities();
            int mlint = int.Parse(maLoaic);
            loaiSP x = db.loaiSPs.Find(mlint);
            isCapNhat = true;
            List<loaiSP> list = db.loaiSPs.OrderBy(z => z.loaiHang).ToList();
            ViewData["danhsachLoai"] = list;
            return View("Index",x);
        }
    }
}