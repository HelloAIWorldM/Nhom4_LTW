using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropCfe.Models
{
    public class DungChung
    {
        static DripCofeEntities data = new DripCofeEntities();
        public static List<sanPham> getProducts()
        {
            var produc = data.Set<sanPham>().ToList();
            return produc;
        }
        public static sanPham getIDproducts(string maSP)
        {
            return data.Set<sanPham>().Find(maSP);
        }
        public static string getImageproducts(string maSP)
        {
            return data.Set<sanPham>().Find(maSP).hinhSP;
        }
        public static int getSoluongs(int soLuong)
        {
            return(int)data.Set<ctDonHang>().Find(soLuong).soLuong;
        }
        public static string getNameproducts(string maSP)
        {
            return data.Set<sanPham>().Find(maSP).tenSP;
        }
        public static List<taiKhoanTV> getUsers()
        {
            List<taiKhoanTV> tkTV = new List<taiKhoanTV>();
            tkTV = data.Set<taiKhoanTV>().ToList<taiKhoanTV>();
            return tkTV;
        }
    }
}