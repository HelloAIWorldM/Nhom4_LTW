using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropCfe.Models;
namespace DropCfe.Areas.VungBaoMat.Controllers
{
    public class DanhSachDHController : Controller
    {
        private static DripCofeEntities db = new DripCofeEntities();
        // GET: VungBaoMat/DanhSachDH
        [HttpGet]
        public ActionResult Index()
        {
            var dsDonhang = db.Set<donHang>().ToList();
            ViewData["danhsachdonhang"] = dsDonhang;
            return View();
        }
        [HttpPost]
        public ActionResult HuyDon(string soDH)
        {
            donHang don = db.donHangs.Find(soDH);
            don.trangthai = -1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult HoanThanh(string soDHss)
        {
            donHang don = db.donHangs.Find(soDHss);
            don.trangthai = 0;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult KichHoat(string soDHs)
        {
            donHang don = db.donHangs.Find(soDHs);
            don.trangthai = 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}