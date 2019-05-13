using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ai_Accessories.Website.Models
{
    public class ClientModel
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();
        public List<CLIENTACCOUNT> Get()
        {
            return db.CLIENTACCOUNTs.ToList();
        }
    }
}