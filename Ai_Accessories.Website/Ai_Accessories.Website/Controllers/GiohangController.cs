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
        public ActionResult Themgiohang(int iId, string sURL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.Find(n => n.iId == iId);
            if (sanpham == null)
            {
                sanpham = new Giohang(iId);
                lstGiohang.Add(sanpham);
                return Redirect(sURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(sURL);
            }
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

        // Trang Giỏ hàng Partial View
        public ActionResult GiohangPartial()
        {
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            return PartialView();
        }
    }
}