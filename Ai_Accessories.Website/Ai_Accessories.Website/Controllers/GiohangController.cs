using Ai_Accessories.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using RouteAttribute = AttributeRouting.Web.Mvc.RouteAttribute;
using PagedList;

namespace Ai_Accessories.Website.Controllers
{
    public class GiohangController : Controller
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();

        // Lấy giỏ hàng
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }

        // Thêm giỏ hàng
        public ActionResult Themgiohang(int idProduct, int quantity)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.Find(n => n.iId == idProduct);
            if (sanpham == null)
            {
                sanpham = new Giohang(idProduct);
                sanpham.iSoluong = quantity;
                lstGiohang.Add(sanpham);
            }
            return RedirectToAction("Index","Product");
        }

        //Tổng số lượng
        private int Tongsoluong()
        {
            int iTongsoluong = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongsoluong = lstGiohang.Sum(n => n.iSoluong);
            }
            return iTongsoluong;
        }

        //Tính tổng tiền
        private double Tongtien()
        {
            double iTongtien = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongtien = lstGiohang.Sum(n => n.dThanhtien);
            }
            return iTongtien;
        }

        // Trang Giỏ hàng
        public ActionResult Giohang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            if(lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Product");
            }
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            return View(lstGiohang);
        } 
        public ActionResult XoaGioHang(int masp)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sampham = lstGiohang.SingleOrDefault(f => f.iId == masp);
            if(sampham != null)
            {
                lstGiohang.RemoveAll(f => f.iId == masp);
                return RedirectToAction("Giohang");
            }
            if(lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Product");
            }
            return RedirectToAction("Giohang");
        }
        public ActionResult UpdateCart(int masp, FormCollection collection)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sampham = lstGiohang.SingleOrDefault(f => f.iId == masp);
            if (sampham != null)
            {
                sampham.iSoluong = int.Parse(collection["quantity"].ToString());
            }
            return RedirectToAction("Giohang");
        }
        public ActionResult ThanhToan()
        {
            var onLogin = Session["Client"];
            if(onLogin == null)
            {
                return RedirectToAction("SignIn", "ClientAccount");
            }
            else
            {
                List<Giohang> lstGiohang = Laygiohang();
                if (lstGiohang.Count == 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                ViewBag.Tongsoluong = Tongsoluong();
                ViewBag.Tongtien = Tongtien(); 

                return View(lstGiohang);
            } 
        }
        public ActionResult HoanTat()
        {
            List<Giohang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            var userName = Session["Client"];
            ViewBag.UserName = userName;

            return View();
        }
    }
}