using System.Collections.Generic;

namespace Agada.Services.Promotion.Requests
{
    public class CouponVerifyRequestModel
    {
        public string Code { get; set; }
        public Dictionary<string, string> Context { get; set; } 
    }
}