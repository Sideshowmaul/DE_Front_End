using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DE_Front_End.Models
{
    public class Product : HttpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryFee { get; set; }
        public int OfferId { get; set; }
        [JsonIgnore]
        public string OfferName { get; set; }
        public Offer Offer { get; set; }
        public Product()
            : base(@"https://localhost:44345/api/product")
        {
        }
    }
}
