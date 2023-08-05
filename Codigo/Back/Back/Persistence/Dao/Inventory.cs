using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HirCasa.Back.Persistence.Dao
{
    [Table("Inventory")]
    public partial class Inventory
    {
        [Key]
        public int Id { get; set; }
        public int Item { get; set; }
        [Column(TypeName = "decimal(15, 3)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CheckIn { get; set; }

        [ForeignKey(nameof(Item))]
        [InverseProperty("Inventories")]
        public virtual Item ItemNavigation { get; set; }
    }
}
