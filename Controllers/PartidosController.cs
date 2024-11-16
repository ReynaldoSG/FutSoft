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
    public class PartidosController : ControllerBase
    {
        private readonly PartidosService _PartidosService;

        public PartidosController(PartidosService partidosService)
        {
            _PartidosService = partidosService;
        }





        [HttpPost("Insert")]
public JsonResult InsertPartidos([FromBody] InsertPartidosModel partidos)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var catClienteResponse = _PartidosService.InsertPartidos(partidos);

        // Suponemos que el mensaje de éxito contiene el ID del registro insertado
        if (catClienteResponse.Contains("Registro insertado con éxito", StringComparison.OrdinalIgnoreCase))
        {
            objectResponse.StatusCode = (int)HttpStatusCode.OK;
            objectResponse.success = true;
            objectResponse.message = "Éxito.";

            // Extraer el ID de la respuesta
            // Suponiendo que CatClienteResponse es algo como "Registro insertado con éxito. ID: 123"
           // int id = ExtractIdFromResponse(catClienteResponse);
            //objectResponse.response = new
            //{
              //  id = id // Agregamos el ID del registro insertado
            //};
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

// Método auxiliar para extraer el ID del mensaje de respuesta
//private int ExtractIdFromResponse(string response)
//{
    // Suponiendo que la respuesta tiene el formato: "Registro insertado con éxito. ID: 123"
  //  var parts = response.Split(new[] { "Id: " }, StringSplitOptions.None);
    //if (parts.Length > 1 && int.TryParse(parts[1], out int id))
    //{
      //  return id; // Devuelve el ID extraído
    //}
    //return 0; // Devuelve 0 si no se puede extraer el ID
//}



        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetPartidos() 
        {
            var objectResponse = Helper.GetStructResponse();
            ResponsePartidos result = new ResponsePartidos();
            result.Response = new ResponseBodyPartidos();
            result.Response.data = new List<GetPartidosModel>();

            var LigaResponse = _PartidosService.GetPartidos();

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


        [HttpPut("Update")]
        public JsonResult UpdatePartidos([FromBody] UpdatePartidosModel partidos)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        // Llama al servicio para actualizar el partido
        var CatClienteResponse = _PartidosService.UpdatePartidos(partidos);

        // Mensajes posibles
        string msgSuccess = "Registro actualizado con éxito.";
        string msgFechaInvalida = "Error. La fecha del partido no puede ser menor a la fecha actual.";

        if (CatClienteResponse == msgSuccess)
        {
            // Respuesta para éxito
            objectResponse.StatusCode = (int)HttpStatusCode.OK;
            objectResponse.success = true;
            objectResponse.message = "Éxito.";
            objectResponse.response = new
            {
                data = CatClienteResponse
            };
        }
        else if (CatClienteResponse == msgFechaInvalida)
        {
            // Respuesta para fecha inválida
            objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            objectResponse.success = false;
            objectResponse.message = "Error: La fecha del partido no puede ser menor a la fecha actual.";
            objectResponse.response = new
            {
                data = CatClienteResponse
            };
        }
        else
        {
            // Respuesta para otros errores
            objectResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            objectResponse.success = false;
            objectResponse.message = "Error al actualizar el registro.";
            objectResponse.response = new
            {
                data = CatClienteResponse
            };
        }
    }
    catch (System.Exception ex)
    {
        Console.Write(ex.Message);

        // Manejo de excepciones
        objectResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        objectResponse.success = false;
        objectResponse.message = "Ocurrió un error inesperado.";
        objectResponse.response = new
        {
            error = ex.Message
        };
    }

    return new JsonResult(objectResponse);
}






        [HttpPut("Delete")]
public JsonResult DeletePartidos([FromBody] DeletePartidosModel partidos)
{
    var objectResponse = Helper.GetStructResponse();
    try
    {
        var catClienteResponse = _PartidosService.DeletePartidos(partidos);

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