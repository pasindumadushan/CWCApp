//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CWCApp.Data.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequestedTOWDetail
    {
        public int DetailId { get; set; }
        public Nullable<int> TOWServiceID { get; set; }
        public Nullable<int> ShopOwnerId { get; set; }
        public Nullable<int> RequesterId { get; set; }
        public string ReqestedCity { get; set; }
        public string ContactNo { get; set; }
        public Nullable<decimal> ApproximateKMs { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}