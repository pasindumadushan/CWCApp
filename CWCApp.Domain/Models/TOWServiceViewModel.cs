using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class TOWServiceViewModel
    {
        public int TOWServiceID { get; set; }
        public Nullable<int> GarageId { get; set; }
        public string GarageName { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ShopOwnerId { get; set; }

        public string TypeOfVehicleOwn { get; set; }
        public Nullable<decimal> MaxPayLoad { get; set; }
        public Nullable<int> NoOfVehicleOwn { get; set; }
        public Nullable<decimal> RatePerKm { get; set; }
        public Nullable<decimal> AvgRate { get; set; }
        public string RangeOfService { get; set; }
        public string ExtraFeatures { get; set; }
        public string VehicleImage { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
