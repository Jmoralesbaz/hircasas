using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Models
{
    public class MItemFull :MItem {
        public int Id { get; set; }
    }
    public class MItem
    {


        public string Item1 { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public bool? Asset { get; set; }
    }
}
