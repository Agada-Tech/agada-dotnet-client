using System;
using System.Collections.Generic;
using Agada.Services.Promotion.Responses.Shared;
using Agada.Services.SmartDeals.Responses.Shared;

namespace Agada.Services.SmartDeals.Responses
{
    public class OfferResponseModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime ExpireDateUtc { get; set; }

        public List<OfferItem> Items { get; set; }
        public double RemainingTime { get; set; }

        public class OfferItem
        {
            public string ItemId { get; set; }
            public OfferVendorItem Vendor { get; set; }
            public ReservationStatus Status { get; set; }
            public AwardModel Award { get; set; }
        }

        public class OfferVendorItem
        {
            public string Id { get; set; }
            public string BannerUrl { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public List<string> Tags { get; set; } 
            public Dictionary<string, string> AdditionalData { get; set; } 
        }
    }
}