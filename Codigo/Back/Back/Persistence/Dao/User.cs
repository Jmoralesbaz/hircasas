using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HirCasa.Back.Persistence.Dao
{
    [Index(nameof(UserName), Name = "UQ__Users__C9F28456B26F36C5", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Sessions = new HashSet<Session>();
        }

        [Key]
        public int Id { get; set; }
        public int Person { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [StringLength(50)]
        public string Rol { get; set; }
        public bool? Asset { get; set; }

        [ForeignKey(nameof(Person))]
        [InverseProperty("Users")]
        public virtual Person PersonNavigation { get; set; }
        [InverseProperty(nameof(Session.IdUserNavigation))]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
