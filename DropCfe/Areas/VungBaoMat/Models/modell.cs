using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropCfe.Models;
namespace DropCfe.Areas.VungBaoMat.Models
{
    public class modell
    {
        private static DripCofeEntities db = new DripCofeEntities();
        public static List<sanPham> GetSanPhams()
        {
            return db.Set<sanPham>().ToList<sanPham>();
        }
        public static Dictionary<string,decimal> TongTienDH()
        {
            var dschitietDH = db.Set<ctDonHang>().ToList<ctDonHang>();
            Dictionary<string, decimal> tongtheosoDH = new Dictionary<string, decimal>();
            foreach(var chitietDH in dschitietDH)
            {
                var soDH = chitietDH.soDH;
                if (tongtheosoDH.ContainsKey(soDH))
                {
                    tongtheosoDH[soDH] += (decimal)chitietDH.giaBan;
                }
                else
                {
                    tongtheosoDH.Add(soDH, (decimal)chitietDH.giaBan);
                }
            }
            return tongtheosoDH;
        }
    }
}