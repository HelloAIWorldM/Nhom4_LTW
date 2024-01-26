using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DropCfe.Models;
namespace DropCfe.Models
{
    public class TaiKhoan
    {
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }
        public TaiKhoan()
        {
            this.taiKhoan = "";
            this.matKhau = "";
        }
        public taiKhoanTV SignIn()
        {
            taiKhoanTV tk = null;
            tk = DungChung.getUsers().Where(a => a.taiKhoan.ToLower().Equals(this.taiKhoan.ToLower()) && a.matKhau.Equals(matKhau)).FirstOrDefault();
            return tk;
        }
    }
}