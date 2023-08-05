using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HirCasa.Back.Persistence.Dao
{
    [Table("Invoice")]
    public partial class Invoice
    {
        [Key]
        [StringLength(150)]
        public string Folio { get; set; }
        public int Sale { get; set; }
        [Required]
        [StringLength(13)]
        public string Rfc { get; set; }
        [Required]
        [StringLength(150)]
        public string RazonSocial { get; set; }
        [Required]
        [StringLength(5)]
        public string CodigoPostal { get; set; }
        [Required]
        [StringLength(150)]
        public string RegimenFiscal { get; set; }
        [Required]
        [StringLength(150)]
        public string UsoCfdi { get; set; }

        [ForeignKey(nameof(Sale))]
        [InverseProperty(nameof(SalesHeader.Invoices))]
        public virtual SalesHeader SaleNavigation { get; set; }
    }
}
