using HirCasa.Back.Bussiness;
using HirCasa.Back.Persistence.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HirCasa.Back.Models;
using System.Collections.Generic;

namespace HirCasa.Back.Controllers
{
    [Route("api/v1/HirCasa/[controller]")]
    public class SalesController : CBase<BSales>
    {
        public SalesController(DbHirCasa _POSContext) : base(_POSContext)
        {
        }
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MSalesDetails>))]
        public IActionResult All()
        {
            return this.ResponseHttp(this.BussinessLayer.GetList());
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(MSales model)
        {
            return this.ResponseHttp(this.BussinessLayer.Create(model));
        }
    }
}
