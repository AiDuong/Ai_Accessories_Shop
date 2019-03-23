using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ai_Accessories.Website.Models
{
    public class SanPhamModel
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();
        public List<SANPHAM> GetSANPHAMs()
        {
            var loaiSP = db.LOAISPs.Where(f => f.Id > 0);
            List<SANPHAM> model = new List<SANPHAM>();

            var data = (from product in db.SANPHAMs
                        join type in loaiSP on product.LoaiSP equals type.Id
                        select new
                        {
                            Id = product.Id,
                            TenSP = product.TenSP,
                            Gia = product.Gia,
                            TenLoaiSP = type.TenloaiSP,
                            ThongtinSP = product.ThongtinSP,
                            HinhanhSP = product.HinhanhSP,
                            Conhang = product.Conhang,
                            Ngaydang = product.Ngaydang
                        }).ToList();

            foreach (var product in data) //retrieve each item and assign to model
            {
                model.Add(new SANPHAM()
                {
                    Id = product.Id,
                    TenSP = product.TenSP,
                    Gia = product.Gia,
                    TenLoaiSP = product.TenLoaiSP,
                    ThongtinSP = product.ThongtinSP,
                    HinhanhSP = product.HinhanhSP,
                    Conhang = product.Conhang,
                    Ngaydang = product.Ngaydang
                });
            }

            return model;
        }
        public List<SANPHAM> GetNewProduct()
        {
            return db.SANPHAMs.OrderByDescending(f => f.Ngaydang).Take(10).ToList();
        }
        public List<SANPHAM> GetbyType(int typeSP, int number)
        {
            return db.SANPHAMs.OrderByDescending(f => f.Ngaydang).Where(f => f.LoaiSP == typeSP).Take(number).ToList();
        }

        public List<SANPHAM> GetSameProduct(int idProduct, int number)
        {
            var obj_product = db.SANPHAMs.FirstOrDefault(f => f.Id == idProduct);
            return db.SANPHAMs.OrderByDescending(f => f.Ngaydang)
                   .Where(f => f.LoaiSP == obj_product.LoaiSP && f.Id != idProduct)
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
        public List<SANPHAM> GetVongtay(int number)
        {
            return db.SANPHAMs.Where(f => f.LoaiSP == 8).Take(number).ToList();
        }
        public List<SANPHAM> GetMockhoaPartial(int number)
        {
            return db.SANPHAMs.Where(f => f.LoaiSP == 1).Take(number).ToList();
        }
        public List<SANPHAM> GetBongtai(int number)
        {
            return db.SANPHAMs.Where(f => f.LoaiSP == 2).Take(number).ToList();
        }
        public List<SANPHAM> GetMaylamtoc(int number)
        {
            return db.SANPHAMs.Where(f => f.LoaiSP == 3).Take(number).ToList();
        }
        public List<SANPHAM> GetCotrangdiem(int number)
        {
            return db.SANPHAMs.Where(f => f.LoaiSP == 15).Take(number).ToList();
        }

        public List<SANPHAM> ProductbyFlag(string flag)
        {
            var loaiSP = db.LOAISPs.Where(f => f.Flag == flag);
            List<SANPHAM> model = new List<SANPHAM>();

            var data = (from product in db.SANPHAMs
                        join type in loaiSP on product.LoaiSP equals type.Id
                        select new
                        {
                            Id = product.Id,
                            TenSP = product.TenSP,
                            Gia = product.Gia,
                            TenLoaiSP = type.TenloaiSP,
                            ThongtinSP = product.ThongtinSP,
                            HinhanhSP = product.HinhanhSP,
                            Conhang = product.Conhang
                        }).ToList();

            foreach (var product in data) //retrieve each item and assign to model
            {
                model.Add(new SANPHAM()
                {
                    Id = product.Id,
                    TenSP = product.TenSP,
                    Gia = product.Gia,
                    TenLoaiSP = product.TenLoaiSP,
                    ThongtinSP = product.ThongtinSP,
                    HinhanhSP = product.HinhanhSP,
                    Conhang = product.Conhang
                });
            }

            return model;
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                SANPHAM product = db.SANPHAMs.Find(id);
                db.SANPHAMs.Remove(product);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    } 
    public partial class SANPHAM
    {
        public string TenLoaiSP { get; set; } 
    }
} 