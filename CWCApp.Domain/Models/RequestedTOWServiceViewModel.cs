using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class RequestedTOWServiceViewModel
    {
        public int DetailId { get; set; }
        public Nullable<int> TOWServiceID { get; set; }
        public string GarageName { get; set; }
        public Nullable<int> ShopOwnerId { get; set; }
        public string ShopOwnerName { get; set; }
        public Nullable<int> RequesterId { get; set; }
        public string RequesterName { get; set; }
        public string ReqestedCity { get; set; }
        public string ContactNo { get; set; }
        public string VehicleImage{ get; set; }
        public string TypeOfVehicle { get; set; }
        public Nullable<decimal> ApproximateKMs { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
