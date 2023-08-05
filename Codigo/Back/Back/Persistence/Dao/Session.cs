using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HirCasa.Back.Persistence.Dao
{
    [Index(nameof(Token), Name = "UQ__Sessions__1EB4F817D784C891", IsUnique = true)]
    public partial class Session
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        [Required]
        [StringLength(500)]
        public string Token { get; set; }
        [Column(TypeName = "date")]
        public DateTime CheckIn { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CheckOut { get; set; }

        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.Sessions))]
        public virtual User IdUserNavigation { get; set; }
    }
}
