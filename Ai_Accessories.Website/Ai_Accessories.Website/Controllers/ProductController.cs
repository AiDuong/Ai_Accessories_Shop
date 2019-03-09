using Ai_Accessories.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using RouteAttribute = AttributeRouting.Web.Mvc.RouteAttribute;

namespace Ai_Accessories.Website.Controllers
{
    public class ProductController : Controller
    {
        //call SP class from Model
        public SanPhamModel sanpham = new SanPhamModel();

        //call Menu class from Model
        public MenuModel menu = new MenuModel();
        // Page Index 
        public ActionResult Index()
        {
            var newProduct = sanpham.GetNewProduct();
            return View(newProduct);
        }
        //page test
        public ActionResult test()
        { 
            return View();
        }
        //Get product by type of product 
        public ActionResult ProductbyType(int type)
        {
            int number = 10;
            var product = sanpham.GetbyType(type, number);
            return PartialView(product);
        }
        //Get List Menu
        public ActionResult Menu()
        {
            var product = menu.Get();
            return PartialView(product);
        }
        // Get all infomation of Product by id 
        public ActionResult ProductDetail(int idProduct)
        {
            var detail = sanpham.GetDetailProduct(idProduct);
            return View(detail);
        }
        // Get HotProduct
        public ActionResult Sanphambanchay(int number)
        {
            var product = sanpham.GetHotProduct(number);
            return PartialView(product);
        }
    }
    enum TypeProduct
    {
        Moc_khoa = 1,
        Bong_tai = 2,
        May_lam_toc = 3, 
        Day_cot_toc = 4,
        But = 5,
        Ve_sinh_giay = 6,
        Giay_di_mua = 7,
        Vong_tay = 8,
        Tui_bop = 9,
        Guong = 10,
        Quat = 11,
        Op_lung =13,
        Mong_tay = 14,
        Co_trang_diem = 15,
        Den = 16,
        Non = 17,
        Son = 18,
        Vo = 19,  
        Dep = 20,
        Dong_ho = 21 
    }
}