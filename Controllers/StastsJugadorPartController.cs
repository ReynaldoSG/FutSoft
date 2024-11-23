using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using System.Linq;
using System.Collections.Generic;


namespace marcatel_api.Controllers
{

    [Route("api/[controller]")]   public class StatJugPartController : ControllerBase
    {
        private readonly StatJugPartService _StatJugPartService;

        public StatJugPartController(StatJugPartService statJugPartService)
        {
            _StatJugPartService = statJugPartService;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetStatJugPart() 
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseStatJugPart result = new ResponseStatJugPart();
            result.Response = new ResponseBodyStatJugPart();
            result.Response.data = new List<GetStatJugPartModel>();

            var LigaResponse = _StatJugPartService.GetStatJugPart();

            if (LigaResponse != null && LigaResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = LigaResponse;
                objectResponse.response = new
                {
                    data = result.Response.data
                };
            }
            else
            {
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Error = true;
                result.Success = false;
                result.Message = "Error al obtener la información.";
            }

            return new JsonResult(result);
        }


        [HttpPost("Insert")]
        public JsonResult InsertStatJugadorPart([FromBody] InsertStatJugPartModel JugPar)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _StatJugPartService.InsertStatJugPart(JugPar);

                string msgDefault = "Registro insertado con éxito.";


                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }


        
        [HttpPut("Update")]
        public JsonResult UpdateStatJugadorPart([FromBody] UpdateStatJugPartModel JugPart)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _StatJugPartService.UpdateStatJugPart(JugPart);

                string msgDefault = "Registro actualizado con éxito.";

                if (msgDefault == CatClienteResponse)
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.OK;
                    objectResponse.success = true;
                    objectResponse.message = "Éxito.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
                else
                {
                    objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    objectResponse.success = true;
                    objectResponse.message = "Error.";

                    objectResponse.response = new
                    {
                        data = CatClienteResponse
                    };
                }
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }


    }
}