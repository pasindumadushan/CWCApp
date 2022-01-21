using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class RequestedRepairServiceViewModel
    {
        public int DetailId { get; set; }
        public Nullable<int> RepairServiceID { get; set; }
        public string GarageName { get; set; }
        public Nullable<int> ShopOwnerId { get; set; }
        public string ShopOwnerName { get; set; }
        public Nullable<int> RequesterId { get; set; }
        public string RequesterName { get; set; }
        public string ReqestedCity { get; set; }
        public string ContactNo { get; set; }
        public Nullable<decimal> RatePerHour { get; set; }
        public Nullable<decimal> RatePerJob { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
