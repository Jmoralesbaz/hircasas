using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HirCasa.Back.Persistence.Dao
{
    [Table("Sales_Headers")]
    public partial class SalesHeader
    {
        public SalesHeader()
        {
            Invoices = new HashSet<Invoice>();
            SalesDetails = new HashSet<SalesDetail>();
        }

        [Key]
        public int Id { get; set; }
        public int Person { get; set; }
        [Column(TypeName = "decimal(15, 3)")]
        public decimal TotalItems { get; set; }
        [Column(TypeName = "decimal(15, 3)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateSale { get; set; }

        [ForeignKey(nameof(Person))]
        [InverseProperty("SalesHeaders")]
        public virtual Person PersonNavigation { get; set; }
        [InverseProperty(nameof(Invoice.SaleNavigation))]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty(nameof(SalesDetail.SaleNavigation))]
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
