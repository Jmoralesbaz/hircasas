using HirCasa.Back.Bussiness;
using HirCasa.Back.Persistence.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HirCasa.Back.Models;
using HirCasa.Back.Uils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HirCasa.Back.Controllers
{

    [Route("api/v1/HirCasa/[controller]")]
    public class UserController : CBase<BUser>
    {
        public UserController(DbHirCasa _POSContext,IConfiguration _options) : base(_POSContext)
        {
            BussinessLayer.Key = _options["Crypt"];
        }
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MUserFull>))]
        public IActionResult All()
        {
            return this.ResponseHttp(this.BussinessLayer.GetList());
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(MUser model)
        {
            return this.ResponseHttp(this.BussinessLayer.Create(model));
        }
        [HttpPut("edit/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult Add(int id, MUser model)
        {
            var m = Reflection.ChangeObject<MUserFull, MUser>(model);
            m.Id = id;
            return this.ResponseHttp(this.BussinessLayer.Update(m));
        }
    }
}
