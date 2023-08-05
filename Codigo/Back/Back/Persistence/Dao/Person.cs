using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HirCasa.Back.Persistence.Dao
{
    [Index(nameof(Email), Name = "UQ__Persons__A9D10534EB96AB85", IsUnique = true)]
    [Index(nameof(Name), nameof(LastName), Name = "uq_name", IsUnique = true)]
    public partial class Person
    {
        public Person()
        {
            SalesHeaders = new HashSet<SalesHeader>();
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        public bool? Asset { get; set; }

        [InverseProperty(nameof(SalesHeader.PersonNavigation))]
        public virtual ICollection<SalesHeader> SalesHeaders { get; set; }
        [InverseProperty(nameof(User.PersonNavigation))]
        public virtual ICollection<User> Users { get; set; }
    }
}
