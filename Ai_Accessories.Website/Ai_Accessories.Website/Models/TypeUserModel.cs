﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ai_Accessories.Website.Models
{
    public class TypeUserModel
    {
        ACCESSORIES_SHOPEntities db = new ACCESSORIES_SHOPEntities();
        public List<LOAIUSER> Get()
        {
            return db.LOAIUSERs.ToList();
        }
    }
}