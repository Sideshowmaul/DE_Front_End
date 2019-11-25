using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Front_End.Models
{
    public class Customer : HttpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLoyal { get; set; }
        public List<Product> Products { get; set; }
        public LoyaltyCard LoyaltyCard { get; set; }
        public Customer()
            : base(@"https://localhost:44345/api/customer")
        {
            Products = new List<Product>();
        }
    }
}
