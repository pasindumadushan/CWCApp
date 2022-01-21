using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class BoughtItemViewModel
    {
        public int DetailsId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Nullable<int> ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public Nullable<int> ShopOwnerId { get; set; }
        public Nullable<int> BuyerId { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string StoreName { get; set; }
        public string DeliveryAddress { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ContactNo { get; set; }
        public Nullable<decimal> RetailPrice { get; set; }
        public Nullable<decimal> WholeSalePrice { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
