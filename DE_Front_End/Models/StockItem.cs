using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DE_Front_End.Models
{
    public class StockItem : HttpModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int StockLevel { get; set; }
        [JsonIgnore]
        public string ProductName { get; set; }
        public Store Store { get; set; }
        public Product Product { get; set; }
        public StockItem()
            : base(@"https://localhost:44345/api/stockitem")
        {
            
        }
    }
}
