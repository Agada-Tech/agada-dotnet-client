using System.Collections.Generic;

namespace Agada.Services.SmartDeals.Requests
{
    public class OfferRequestModel
    {
        public HashSet<string> VendorIds { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}