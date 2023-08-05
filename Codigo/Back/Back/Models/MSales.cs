using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Models
{
    public class  MSalesDetails{
        public int Id { get; set; }
        public int Person { get; set; }
        public decimal TotalItems { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DateSale { get; set; }
        public List<MSalesItem> Items { get; set; }
    }
    public class MSalesItem {
        public int Item { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
    public class MSales
    {
        public int Person { get; set; }
        public List<MSalesItem> Items { get; set; }
    }
    
}
