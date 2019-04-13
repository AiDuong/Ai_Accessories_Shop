using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ai_Accessories.Website.Models
{
    public class UserModel
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();
        public List<USER> Get()
        {
            return db.USERs.ToList();
        }
    }
}