using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class VehiclePartsStoreItemViewModel
    {
        public int ItemId { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string StoreName { get; set; }
        public Nullable<int> UserId { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public Nullable<int> ItemTotalAmount { get; set; }
        public Nullable<int> ItemBoughtAmount { get; set; }
        public Nullable<int> ItemBalance { get; set; }
        public string ItemBrand { get; set; }
        public string ItemImage { get; set; }
        public string ItemDiscription { get; set; }
        public Nullable<decimal> RetailPrice { get; set; }
        public Nullable<decimal> WholeSalePrice { get; set; }
        public string ItemSpecs { get; set; }
        public Nullable<decimal> AvgRate { get; set; }
        public Nullable<bool> IsActive { get; set; }


        //store info
        public Nullable<int> ServiceId { get; set; }
        public string ContactNumber { get; set; }
        public string AddressOfStore { get; set; }
        public Nullable<int> ShoppingMethod { get; set; }
    }
}
