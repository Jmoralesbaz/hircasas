using HirCasa.Back.Bussiness;
using HirCasa.Back.Persistence.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HirCasa.Back.Models;
using HirCasa.Back.Uils;

namespace HirCasa.Back.Controllers
{
    [Route("api/v1/HirCasa/[controller]")]
    public class ItemController : CBase<BItem>
    {
        public ItemController(DbHirCasa _POSContext) : base(_POSContext)
        {
        }
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MItemFull>))]
        public IActionResult All()
        {
            return this.ResponseHttp(this.BussinessLayer.GetList());
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(MItem model)
        {
            return this.ResponseHttp(this.BussinessLayer.Create(model));
        }
        [HttpPut("edit/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(int id, MItem model)
        {
            var m = Reflection.ChangeObject<MItemFull, MItem>(model);
            m.Id = id;
            return this.ResponseHttp(this.BussinessLayer.Update(m));
        }
    }
}
