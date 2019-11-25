using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DE_Front_End.Models
{
    public class Store : HttpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StockItem> Inventory { get; set; }
        public Store()
            : base(@"https://localhost:44345/api/store")
        {
            Inventory = new List<StockItem>();
        }
    }
}
