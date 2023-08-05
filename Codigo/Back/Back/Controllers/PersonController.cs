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
    public class PersonController : CBase<BPerson>
    {
        public PersonController(DbHirCasa _POSContext) : base(_POSContext)
        {
        }
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MPersonFull>))]
        public IActionResult All()
        {
            return this.ResponseHttp(this.BussinessLayer.GetList());
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(MPerson model)
        {
            return this.ResponseHttp(this.BussinessLayer.Create(model));
        }
        [HttpPut("edit/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult update(int id, MPerson model)
        {
            var m = Reflection.ChangeObject<MPersonFull, MPerson>(model);
            m.Id = id;
            return this.ResponseHttp(this.BussinessLayer.Update(m));
        }
        [HttpPut("asset/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult asset(int id)
        {            
            return this.ResponseHttp(this.BussinessLayer.Asset(id));
        }
    }
}
