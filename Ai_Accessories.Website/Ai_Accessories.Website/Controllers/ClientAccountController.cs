using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ai_Accessories.Website.Models;

namespace Ai_Accessories.Website.Controllers
{
    public class ClientAccountController : Controller
    {
        private ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();


        // GET: CLIENTACCOUNTs 
        [HttpGet]
        public ActionResult SignIn()
        { 
            return View();
        }
        public async Task<ActionResult> SignIn(FormCollection collection)
        {
            var account = collection["Account"];
            var password = collection["Password"];
            if (!string.IsNullOrEmpty(account))
            {
                CLIENTACCOUNT client = await db.CLIENTACCOUNTs.SingleOrDefaultAsync(f => f.AccountName == account && f.PassWord == password);
                if (client != null)
                {
                    Session["Client"] = client;
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: CLIENTACCOUNTs/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: CLIENTACCOUNTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(CLIENTACCOUNT cLIENTACCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTACCOUNTs.Add(cLIENTACCOUNT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Product");
            }

            return View(cLIENTACCOUNT);
        } 
    }
}
