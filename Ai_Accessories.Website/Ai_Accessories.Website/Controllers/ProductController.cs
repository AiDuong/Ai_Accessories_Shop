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
        #region--Private--
        
        //call SP class from Model
        private SanPhamModel sanpham = new SanPhamModel();

        //call Menu class from Model
        private MenuModel menu = new MenuModel();

        private readonly int pageSize = 10;

        #endregion

        #region --HomePage--
        [Route("trang-chu")]
        public ActionResult Index()
        {
            var newProduct = sanpham.GetNewProduct();
            return View(newProduct);
        }
        #endregion

        #region--ProductbyType--

        [Route("san-pham-theo-loai/{flag}?page={page}")]
        public ActionResult ProductbyType(string flag, int? page)
        {
            int pageNumber = (page ?? 1);
            var posts = sanpham.ProductbyFlag(flag);
            @ViewBag.TotalProduct = posts.Count();
            return View(posts.ToList().ToPagedList(pageNumber, pageSize));
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

        #region--Menu--

        public ActionResult Menu()
        {
            var product = menu.Get();
            return PartialView(product);
        }

        #endregion

        #region--ProductDetail--

        /// <summary>
        /// Get all infomation of Product by id 
        /// </summary>
        /// <param name="idProduct">Id of Product</param>
        /// <returns></returns>
        [Route("chi-tiet-san-pham/{idProduct}")]
        public ActionResult Chitietsanpham(int idProduct)
        {
            var detail = sanpham.GetDetailProduct(idProduct);
            return View(detail);
        }

        public ActionResult PartialSanPhamLienQuan(int number)
        {
            var currentProduct = Int32.Parse(Request.Url.AbsoluteUri.Split('/')[4]);
            var product = sanpham.GetSameProduct(currentProduct, number);

            var rand = new Random();
            var sameProduct = product.Skip(rand.Next(product.Count)).ToList();

            return PartialView(sameProduct);
        }

        #endregion

        #region--PartialforIndex--
         
        public ActionResult PartialSanPhamBanChay(int number)
        {
            var product = sanpham.GetHotProduct(number);
            return PartialView(product);
        }

        public ActionResult PartialVongTay(int number)
        {
            var product = sanpham.GetVongtay(number);
            return PartialView(product);
        }

        public ActionResult PartialMockhoa(int number)
        {
            var product = sanpham.GetMockhoaPartial(number);
                return PartialView(product);
        }

        public ActionResult PartialBongtai(int number)
        {
            var product = sanpham.GetBongtai(number);
            return PartialView(product);
        }

        public ActionResult PartialMayLamToc(int number)
        {
            var product = sanpham.GetMaylamtoc(number);
            return PartialView(product);
        }

        public ActionResult PartialCoTrangDiem(int number)
        {
            var product = sanpham.GetCotrangdiem(number);
            return PartialView(product);
        }
        
        #endregion

    }
}