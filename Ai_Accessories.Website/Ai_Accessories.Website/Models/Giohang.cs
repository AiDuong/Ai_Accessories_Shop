using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ai_Accessories.Website.Models
{
    public class Giohang
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();

        public int iId { set; get; }
        public string sTenSP { set; get; }
        public string sHinhanhSP { set; get; }
        public Double dGia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dGia; }
        }

        public Giohang (int Id)
        {
            iId = Id;
            SANPHAM sanpham = db.SANPHAMs.Single(n => n.Id == iId);
            sTenSP = sanpham.TenSP;
            sHinhanhSP = sanpham.HinhanhSP;
            dGia = double.Parse(sanpham.Gia.ToString());
            iSoluong = 1;
        }
    }
}