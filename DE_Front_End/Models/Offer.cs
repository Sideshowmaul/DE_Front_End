using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Front_End.Models
{
    public class Offer : HttpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Offer()
            : base(@"https://localhost:44345/api/offer")
        {
            Products = new List<Product>();
 
        }
    }
}
