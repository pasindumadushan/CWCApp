using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class RequestedRentalServiceViewModel
    {
        public int DetailId { get; set; }
        public Nullable<int> RentalServiceID { get; set; }
        public string RantalServiceName { get; set; }
        public string TypeOfVehicleOwn { get; set; }

        public Nullable<int> ShopOwnerId { get; set; }
        public string ShopOwnerName { get; set; }
        public Nullable<int> RequesterId { get; set; }
        public string RequesterName { get; set; }
        public string RequestedCity { get; set; }
        public string ContactNo { get; set; }
        public Nullable<decimal> RatePerKM { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
