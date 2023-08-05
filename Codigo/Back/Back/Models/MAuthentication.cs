using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Models
{
    public class JWToken {
        public string Token { get; set; }
        public MAuthentication DataUser { get; set; }
    }
    public class MAuthentication
    {
        public string Rol { get; set; }
        public int Person { get; set; }
        public string User { get; set; }
        
        public double Expired { get; set; }

    }
}
