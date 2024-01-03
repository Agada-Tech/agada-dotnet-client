using System.Collections.Generic;
using Agada.Services.Promotion.Responses.Shared;

namespace Agada.Services.Promotion.Responses
{
    public class CouponValidationModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public AwardModel Award { get; set; }
        public bool IsValid { get; set; }
        public string Code { get; set; }
        public MessagesModel Messages { get; set; }

        public class MessagesModel
        {
            public MessagesModel()
            {
                InfoMessages = new List<string>();
                ErrorMessages = new List<string>();
            }

            public List<string> InfoMessages { get; set; }
            public List<string> ErrorMessages { get; set; }
        }
    }
}