using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Front_End.Models
{
    public class LoyaltyCard : HttpModel
    {
        public int Id { get; set; }
        public int Discount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public LoyaltyCard()
            : base(@"https://localhost:44345/api/loyaltycard")
        {
        }
    }
}
