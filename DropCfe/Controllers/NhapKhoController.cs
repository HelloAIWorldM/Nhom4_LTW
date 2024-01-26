using DropCfe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropCfe.Controllers
{
    public class NhapKhoController : Controller
    {
        private readonly DripCofeEntities db = new DripCofeEntities();
        // GET: VungBaoMat/ThemSanPham
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(sanPham product)
        {
            HttpPostedFileBase file = Request.Files["file"];

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    file.SaveAs(path);

                    product.hinhSP = "/Images/" + fileName;
                }

                db.sanPhams.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}