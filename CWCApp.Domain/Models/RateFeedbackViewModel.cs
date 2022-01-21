using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWCApp.Domain.Models
{
    public class RateFeedbackViewModel
    {
        public int RateId { get; set; }
        public Nullable<int> RatedUserId { get; set; }
        public string RatedUserName { get; set; }
        public Nullable<int> ServiceProviderId { get; set; }
        public Nullable<int> ServiceProviderType { get; set; }
        public Nullable<int> ProductOrServiceId { get; set; }
        public Nullable<decimal> RatedValue { get; set; }
        public int FeedBackId { get; set; }
        public string FeedBack1 { get; set; }
        public int ServiceFeedBackId { get; set; }
        public string ServiceFeedBack1 { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
