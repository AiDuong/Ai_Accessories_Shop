//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ai_Accessories.Website.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Hoten { get; set; }
        public Nullable<int> LoaiUser { get; set; }
    
        public virtual LOAIUSER LOAIUSER1 { get; set; }
    }
}
