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
    
    public partial class RepairService
    {
        public int RepairServiceID { get; set; }
        public Nullable<int> GarageId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<decimal> TravelRange { get; set; }
        public string VehicleExpertise { get; set; }
        public Nullable<decimal> RatePerHour { get; set; }
        public Nullable<decimal> RatePerJob { get; set; }
        public string ExtraFeatures { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}