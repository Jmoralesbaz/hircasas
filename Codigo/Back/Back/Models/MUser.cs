using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Models
{
    public class MUserFull: MUser
    {
        public int Id { get; set; }
    }
    public class MUser
    {
        public int Person { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public bool? Asset { get; set; }
    }
    public enum Roles {
        Administrator=1,
        Customer=2
    }
}
