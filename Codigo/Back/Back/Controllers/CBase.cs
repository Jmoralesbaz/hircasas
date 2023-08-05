using HirCasa.Back.Bussiness;
using HirCasa.Back.Models;
using HirCasa.Back.Uils;
using HirCasa.Back.Persistence.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace HirCasa.Back.Controllers
{
    [Authorize]
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MessagesError))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MessagesError))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(MessagesError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MessagesError))]
    public class CBase<T> : ControllerBase where T : BBase
    {
        protected T BussinessLayer = default(T);
        public CBase(DbHirCasa _POSContext)
        {
            BussinessLayer = Reflection.CreateInstaceClass<T>(typeof(T), _POSContext);
        }

        protected IActionResult ResponseHttp<TRespuesta>(Result<TRespuesta> respuestaGeneral)
        {
            IActionResult result;
            switch (respuestaGeneral.code)
            {
                case 200:
                    result = Ok((object)respuestaGeneral.data);
                    break;
                case 201:
                    result = StatusCode(201);
                    break;
                case 204:
                    result = NoContent();
                    break;
                default:
                    result = StatusCode(respuestaGeneral.code, new MessagesError { Id = respuestaGeneral.code, Message = respuestaGeneral.message });
                    break;
            }

            return result;
        }
       
    }
}
