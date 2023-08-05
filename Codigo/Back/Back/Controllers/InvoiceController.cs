using HirCasa.Back.Bussiness;
using HirCasa.Back.Persistence.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HirCasa.Back.Models;
using Microsoft.AspNetCore.Http;
using HirCasa.Back.Uils;

namespace HirCasa.Back.Controllers
{
    [Route("api/v1/HirCasa/[controller]")]
    public class InvoiceController : CBase<BInvoice>
    {
        public InvoiceController(DbHirCasa _POSContext) : base(_POSContext)
        {
        }
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MInvoiceFull>))]
        public IActionResult All()
        {
            return this.ResponseHttp(this.BussinessLayer.GetList());
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(MInvoice model)
        {
            return this.ResponseHttp(this.BussinessLayer.Create(model));
        }
        [HttpPut("edit/{folio}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(string folio, MInvoice unit)
        {
            var m = Reflection.ChangeObject<MInvoiceFull, MInvoice>(unit);
            m.Folio = folio;
            return this.ResponseHttp(this.BussinessLayer.Update(m));
        }
    }
}
