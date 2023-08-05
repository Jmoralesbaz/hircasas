using HirCasa.Back.Bussiness;
using HirCasa.Back.Models;
using HirCasa.Back.Persistence.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Controllers
{
    [Route("api/v1/HirCasa/[controller]")]
    public class InventoryController : CBase<BInventory>
    {
        public InventoryController(DbHirCasa _POSContext) : base(_POSContext)
        {
        }

        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MInventoryFull>))]
        public IActionResult All()
        {
            return this.ResponseHttp(this.BussinessLayer.GetList());
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(MInventory model)
        {
            return this.ResponseHttp(this.BussinessLayer.Create(model));
        }
    }
}
