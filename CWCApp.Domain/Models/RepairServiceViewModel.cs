using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class RepairServiceViewModel
    {
        public int RepairServiceID { get; set; }
        public Nullable<int> GarageId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string GarageName { get; set; }
        public Nullable<decimal> TravelRange { get; set; }
        public string VehicleExpertise { get; set; }
        public Nullable<decimal> RatePerHour { get; set; }
        public Nullable<decimal> RatePerJob { get; set; }
        public Nullable<decimal> AvgRate { get; set; }
        public string ExtraFeatures { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
