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
    public class RolesController : Controller
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();

        //call SP class from Model
        public TypeUserModel typeUser = new TypeUserModel();

        // GET: Admin
        public ActionResult List(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var users = typeUser.Get();
            @ViewBag.TotalProduct = users.Count();
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        { 
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LOAIUSER type)
        {
            if (ModelState.IsValid)
            {
                db.LOAIUSERs.Add(type);
                db.SaveChanges();
                return RedirectToAction("List");
            }
             
            return View(type);
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                LOAIUSER type = db.LOAIUSERs.Find(id);

                if (type == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                } 
                return View(type);
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
        public ActionResult Edit(LOAIUSER type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            } 
            return View(type);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                LOAIUSER type = db.LOAIUSERs.Find(id);

                if (type == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                ViewBag.LoaiUser = new SelectList(db.LOAIUSERs, "MaloaiUser", "TenloaiUser");
                return View(type);
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
            LOAIUSER type = db.LOAIUSERs.Find(id);
            db.LOAIUSERs.Remove(type);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}