using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Models
{
    public class MInvoiceFull : MInvoice {
        public string Folio { get; set; }
    }
    public class MInvoice
    {
        public int Sale { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string RegimenFiscal { get; set; }
        public string UsoCfdi { get; set; }
    }
}
