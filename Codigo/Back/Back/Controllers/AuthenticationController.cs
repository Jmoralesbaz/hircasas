using HirCasa.Back.Bussiness;
using HirCasa.Back.Models;
using HirCasa.Back.Persistence.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirCasa.Back.Controllers
{

    [Route("api/v1/HirCasa/[controller]")]
    public class AuthenticationController : CBase<BAuthentication>
    {
        public AuthenticationController(DbHirCasa _POSContext, IConfiguration configuration) : base(_POSContext)
        {
            BussinessLayer.Key = configuration["Crypt"];
            BussinessLayer.SecretJWT = configuration["Audenci:akl"];
            BussinessLayer.TimeJWT = double.Parse(configuration["Audenci:tsw"]);
        }
      
        [HttpPost("Login")]        
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JWToken))]
        public IActionResult Login(MLogin login)
        {
            return this.ResponseHttp(BussinessLayer.Login(login));
        }
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public IActionResult LogOut()
        //{
        //    var tok = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        //    return this.ResponseHttp(jwttokenservice.LogOut(tok));
        //}
    }
}
