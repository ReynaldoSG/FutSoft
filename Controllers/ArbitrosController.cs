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

    [Route("api/[controller]")]
    public class ArbitrosController : ControllerBase
    {
        private readonly ArbService _arbtsService;

        public ArbitrosController(ArbService arbtsService)
        {
            _arbtsService = arbtsService;
        }





        [HttpPost("Insert")]
        public JsonResult InsertArbitros([FromBody] InsertArbModel arbitros)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _arbtsService.InsertArb(arbitros);

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



        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetArbitros()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseArb result = new ResponseArb();
            result.Response = new ResponseBodyArb();
            result.Response.data = new List<GetArbModel>();

            var ResponseArb = _arbtsService.GetArbs();

            if (ResponseArb != null && ResponseArb.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = ResponseArb;
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


        [HttpPut("Update")]
        public JsonResult UpdateArbitros([FromBody] UpdateArbModel arbitros)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _arbtsService.UpdateArb(arbitros);

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

 [HttpPut("Delete")]
public JsonResult DeleteArbitros([FromBody] DeleteArbModel arb)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var catClienteResponse = _arbtsService.DeleteArbitros(arb);

        // Suponemos que el mensaje de éxito contiene la frase "Registro eliminado con éxito"
        if (catClienteResponse.Contains("Registro eliminado con éxito", StringComparison.OrdinalIgnoreCase))
        {
            objectResponse.StatusCode = (int)HttpStatusCode.OK;
            objectResponse.success = true;
            objectResponse.message = "Éxito.";

            objectResponse.response = new
            {
                data = catClienteResponse
            };
        }
        else
        {
            objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            objectResponse.success = false; // Cambiado a false para indicar un error
            objectResponse.message = "Error: " + catClienteResponse; // Incluye el mensaje de error de la SP

            objectResponse.response = new
            {
                data = catClienteResponse
            };
        }
    }
    catch (System.Exception ex)
    {
        Console.Write(ex.Message);
        objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError; // Cambia a 500 en caso de excepción
        objectResponse.success = false;
        objectResponse.message = "Error interno del servidor: " + ex.Message;
    }

    return new JsonResult(objectResponse);
}

} 
}