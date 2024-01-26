using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropCfe.Models
{
    public class GioHang
    {
        public string maKH { get; set; }
        public string taiKhoan { get; set; }
        public DateTime ngayDat { get; set; }
        public DateTime ngayGH { get; set; }
        public string diaChi { get; set; }
        public SortedList<string, ctDonHang> ChonSP { get; set; }
        public GioHang()
        {
            this.maKH = "";
            this.taiKhoan = "";
            this.ngayDat = DateTime.Now;
            this.ngayGH = DateTime.Now.AddDays(2);
            this.diaChi = "";
            this.ChonSP = new SortedList<string, ctDonHang>();
        }
        public bool CheckGioHang()
        {
            return (ChonSP.Keys.Count == 0);
        }
        public void themSP(string maSP)
        {
            if (!string.IsNullOrEmpty(maSP))
            {
                if (ChonSP.ContainsKey(maSP))
                {
                    ctDonHang dh = ChonSP[maSP];
                    dh.soLuong++;
                    capnhatSP(dh);
                }
                else
                {
                    sanPham sp = DungChung.getIDproducts(maSP);
                    if (sp != null)
                    {
                        ctDonHang dh = new ctDonHang();
                        dh.maSP = maSP;
                        dh.soLuong = 1;
                        dh.giaBan = sp.giaBan;
                        ChonSP.Add(maSP, dh);
                    }
                    else
                    {
                        throw new InvalidOperationException("Không thể lấy thông tin sản phẩm");
                    }
                }
            }
            else
            {
throw new ArgumentException("Mã sản phẩm không hợp lệ");
            }
        }

        public void capnhatSP(ctDonHang x)
        {
            this.ChonSP.Remove(x.maSP);
            this.ChonSP.Add(x.maSP,x);
        }
        public void xoaSP(string maSP)
        {
            if (ChonSP.Keys.Contains(maSP))
            {
                ChonSP.Remove(maSP);
            }
        }
        public void giamSP(string maSP)
        {
            if (ChonSP.Keys.Contains(maSP))
            {
                ctDonHang dh = ChonSP.Values[ChonSP.IndexOfKey(maSP)];
                if (dh.soLuong > 1)
                {
                    dh.soLuong--;
                    capnhatSP(dh);
                }
                else
                {
                    xoaSP(maSP);
                }
            }
        }
        public long tienSp(ctDonHang dh)
        {
            return (long)dh.soLuong*(long)dh.giaBan;
        }
        public long tongtienGH()
        {
            long sum = 0;
            foreach (ctDonHang i in ChonSP.Values)
                sum += tienSp(i);
            return sum;
        }
        public int tongSLSP()
        {
            int tong = 0;
            foreach (ctDonHang i in ChonSP.Values)
                tong += (int)i.soLuong;
            return tong;
        }
    }
}