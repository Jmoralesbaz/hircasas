using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Models
{
    public class MPersonFull: MPerson
    {
        public int Id { get; set; }
    }
    public class MPerson
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? Asset { get; set; }
    }
}
