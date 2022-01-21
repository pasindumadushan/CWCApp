using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class VehiclePartsStoreViewModel
    {
        public int StoreId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public string StoreName { get; set; }
        public string ContactNumber { get; set; }
        public string AddressOfStore { get; set; }
        public Nullable<int> ShoppingMethodId { get; set; }
        public string ShoppingMethod { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
