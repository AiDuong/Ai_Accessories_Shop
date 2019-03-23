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
    public class ProductController : Controller
    {
        //call SP class from Model
        public SanPhamModel sanpham = new SanPhamModel();

        //call Menu class from Model
        public MenuModel menu = new MenuModel();

        public readonly int pageSize = 10;

        #region --Home Page--
        [Route("trang-chu")]
        public ActionResult Index()
        {
            var newProduct = sanpham.GetNewProduct();
            return View(newProduct);
        }
        #endregion

        #region --Contact Page--
        [Route("lien-he")]
        public ActionResult Contact()
        {
            return View();
        }
        #endregion

        #region --About--
        [Route("cong-ty")]
        public ActionResult About()
        {
            return View();
        }
        #endregion

        [Route("san-pham-theo-loai/{flag}?page={page}")]
        public ActionResult Mockhoa(string flag,int? page)
        { 
            int pageNumber = (page ?? 1); 
            var posts = sanpham.ProductbyFlag(flag);
            @ViewBag.TotalProduct = posts.Count();
            return View(posts.ToList().ToPagedList(pageNumber, pageSize));
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
        [Route("chi-tiet-san-pham/{idProduct}")]
        public ActionResult Chitietsanpham(int idProduct)
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

        public ActionResult Vongtay(int number)
        {
            var product = sanpham.GetVongtay(number);
            return PartialView(product);
        }
        public ActionResult MockhoaPartial(int number)
        {
            var product = sanpham.GetMockhoaPartial(number);
                return PartialView(product);
        }
        public ActionResult Bongtai(int number)
        {
            var product = sanpham.GetBongtai(number);
            return PartialView(product);
        }
        public ActionResult Maylamtoc(int number)
        {
            var product = sanpham.GetMaylamtoc(number);
            return PartialView(product);
        }
        public ActionResult Cotrangdiem(int number)
        {
            var product = sanpham.GetCotrangdiem(number);
            return PartialView(product);
        }



        #region--test--
        //page test
        public ActionResult test()
        {
            return View();
        }
        #endregion
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