using Ai_Accessories.Website.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ai_Accessories.Website.Area.Admin.Controllers
{
    public class UserController : Controller
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();

        //call SP class from Model
        public UserModel user = new UserModel();

        // GET: Admin
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var users = user.Get();
            @ViewBag.TotalProduct = users.Count();
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            ViewBag.LoaiUser = new SelectList(db.LOAIUSERs, "MaloaiUser", "TenloaiUser");
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.USERs.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiUser = new SelectList(db.LOAIUSERs, "MaloaiUser", "TenloaiUser", uSER.LoaiUser);
            return View(uSER);
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                USER uSER = db.USERs.Find(id);

                if (uSER == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                ViewBag.LoaiUser = new SelectList(db.LOAIUSERs, "MaloaiUser", "TenloaiUser");
                return View(uSER);
            }
            catch (Exception ex)    
            { 
                throw ex;
            } 
        }

        // POST: USERzs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiUser = new SelectList(db.LOAIUSERs, "MaloaiUser", "TenloaiUser", uSER.LoaiUser);
            return View(uSER);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                USER uSER = db.USERs.Find(id);

                if (uSER == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                ViewBag.LoaiUser = new SelectList(db.LOAIUSERs, "MaloaiUser", "TenloaiUser");
                return View(uSER);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER uSER = db.USERs.Find(id);
            db.USERs.Remove(uSER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}