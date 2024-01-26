using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropCfe.Models;
namespace DropCfe.Areas.VungBaoMat.Controllers
{
    public class DanhSachKHController : Controller
    {
        // GET: VungBaoMat/DanhSachKH
        public ActionResult Index()
        {
            DripCofeEntities db = new DripCofeEntities();
            var dsKhachHang = db.Set<khachhang>().ToList();
            ViewData["KhachHang"] = dsKhachHang;
            return View();
        }
    }
}