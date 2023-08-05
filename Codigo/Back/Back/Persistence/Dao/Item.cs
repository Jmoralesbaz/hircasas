using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HirCasa.Back.Persistence.Dao
{
    [Index(nameof(Item1), Name = "UQ__Items__9CBB9A4E33C1C138", IsUnique = true)]
    public partial class Item
    {
        public Item()
        {
            Inventories = new HashSet<Inventory>();
            SalesDetails = new HashSet<SalesDetail>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Item")]
        [StringLength(150)]
        public string Item1 { get; set; }
        [Column(TypeName = "decimal(15, 5)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(15, 3)")]
        public decimal Stock { get; set; }
        public bool? Asset { get; set; }

        [InverseProperty(nameof(Inventory.ItemNavigation))]
        public virtual ICollection<Inventory> Inventories { get; set; }
        [InverseProperty(nameof(SalesDetail.ItemNavigation))]
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
