using Ai_Accessories.Website.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ai_Accessories.Website.Area.Admin.Controllers
{
    public class AdminController : Controller
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();

        //call SP class from Model
        public SanPhamModel sanpham = new SanPhamModel();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Product(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var posts = sanpham.GetSANPHAMs();
            @ViewBag.TotalProduct = posts.Count();
            return View(posts.ToPagedList(pageNumber, pageSize));
        } 

        public ActionResult DeleteProduct(int id)
        {
            bool Xoasanpham = sanpham.DeleteProduct(id);
            if (Xoasanpham == true)
            {
                return RedirectToAction("Product", new { page = 1 });
            }
            else
            {
                return RedirectToAction("Product", new { page = 1 });
            }
        }
    }
}