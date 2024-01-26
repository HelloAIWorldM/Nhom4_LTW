using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DropCfe.Models;
namespace DropCfe.Areas.VungBaoMat.Controllers
{
    public class ThongTinSPController : Controller
    {
        private static DripCofeEntities db = new DripCofeEntities();
        // GET: VungBaoMat/ThongTinSP
        [HttpGet]
        public ActionResult Index(string maSP)
        {   sanPham proc = db.sanPhams.Find(maSP);
            return View(proc);
            
        }
        [HttpPost]
        public ActionResult LuuData(string maSP, sanPham capnhatSP)
        {
            sanPham san = db.sanPhams.Find(maSP);
            if (san != null)
            {
                san.tenSP = capnhatSP.tenSP;
                san.ndTomTat = capnhatSP.ndTomTat;
                san.giaBan = capnhatSP.giaBan;
                db.Entry(san).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "DanhSachSP");
        }
    }
}