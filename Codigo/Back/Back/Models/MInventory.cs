using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Models
{
    public class MInventoryFull: MInventory {
        public int Id { get; set; }
        public string ItemName { get; set; }
    }
  
    public class MInventory
    {
        public int Item { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? CheckIn { get; set; }
    }
}
