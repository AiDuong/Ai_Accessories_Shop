using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ai_Accessories.Website.Models
{
    public class SanPhamModel
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();
        public List<SANPHAM> GetSANPHAMs()
        {
            return db.SANPHAMs.OrderByDescending(f => f.Ngaydang).ToList();
        }
        public List<SANPHAM> GetNewProduct()
        {
            return db.SANPHAMs.OrderByDescending(f => f.Ngaydang).Take(10).ToList();
        }
        public List<SANPHAM> GetbyType(int typeSP, int number)
        {
            return db.SANPHAMs.OrderByDescending(f=>f.Ngaydang).Where(f=>f.LoaiSP == typeSP).Take(number).ToList();
        }

        public List<SANPHAM> GetSameProduct(int idProduct,int number)
        {
            var obj_product = db.SANPHAMs.FirstOrDefault(f => f.Id == idProduct);
            return db.SANPHAMs.OrderByDescending(f => f.Ngaydang)
                   .Where(f=>f.LoaiSP == obj_product.LoaiSP && f.Id != idProduct)
                   .Take(number).ToList();
        }

        public SANPHAM GetDetailProduct(int idProduct)
        {
            return db.SANPHAMs.FirstOrDefault(f => f.Id == idProduct);
        }
        public List<SANPHAM> GetHotProduct(int number)
        {
            return db.SANPHAMs.OrderByDescending(f => f.Solanmua).Take(number).ToList();
        }
    }
}