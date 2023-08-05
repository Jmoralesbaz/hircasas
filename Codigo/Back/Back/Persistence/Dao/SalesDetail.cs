using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HirCasa.Back.Persistence.Dao
{
    [Table("Sales_Details")]
    public partial class SalesDetail
    {
        [Key]
        public int Sale { get; set; }
        [Key]
        public int Item { get; set; }
        [Column(TypeName = "decimal(15, 3)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(15, 5)")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Item))]
        [InverseProperty("SalesDetails")]
        public virtual Item ItemNavigation { get; set; }
        [ForeignKey(nameof(Sale))]
        [InverseProperty(nameof(SalesHeader.SalesDetails))]
        public virtual SalesHeader SaleNavigation { get; set; }
    }
}
