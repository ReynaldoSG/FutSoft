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
    public class TemporadasController : ControllerBase
    {
        private readonly TemporadasService _TemporadasService;

        public TemporadasController(TemporadasService temporadasService)
        {
            _TemporadasService = temporadasService;
        }





        [HttpPost("Insert")]
        public JsonResult InsertTemporadas([FromBody] InsertTemporadasModel temp)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _TemporadasService.InsertTemporadas(temp);

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
        public IActionResult GetTemporadas()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseTemporadas result = new ResponseTemporadas();
            result.Response = new ResponseBodyTemporadas();
            result.Response.data = new List<GetTemporadasModel>();

            var TempResponse = _TemporadasService.GetTemporadas();

            if (TempResponse != null && TempResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = TempResponse;
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
        public JsonResult UpdateTemporadas([FromBody] UpdateTemporadasModel temp)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _TemporadasService.UpdateTemporadas(temp);

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
        public JsonResult DeleteTemporadas([FromBody] DeleteTemporadasModel temp)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var catClienteResponse = _TemporadasService.DeleteTemporadas(temp);

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