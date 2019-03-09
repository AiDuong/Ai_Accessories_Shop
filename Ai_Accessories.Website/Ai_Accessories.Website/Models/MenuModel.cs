using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ai_Accessories.Website.Models
{
    public class MenuModel
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();
        public List<MENU> Get()
        {
            return db.MENUs.ToList();
        }
    }
}