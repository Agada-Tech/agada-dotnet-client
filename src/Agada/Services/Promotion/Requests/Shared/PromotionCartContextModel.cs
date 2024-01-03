using System;
using System.Collections.Generic;

namespace Agada.Services.Promotion.Requests.Shared
{
    public class PromotionCartContextModel
    {
        public string UserId { get; set; }
        public string ChannelName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ItemModel> Items { get; set; }
        public List<VendorModel> Vendors { get; set; } 
        public class ItemModel
        {
            public string ProductId { get; set; } 
            public string ProductName { get; set; }
            public List<string> Categories { get; set; } 
            public List<string> Tags { get; set; } 
            public string VendorId { get; set; } 
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }

        public class VendorModel
        {
            public string VendorId { get; set; } 
            public string VendorName { get; set; }
            public List<string> Tags { get; set; }
        }
    }
}