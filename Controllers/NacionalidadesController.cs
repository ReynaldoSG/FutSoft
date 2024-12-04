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
    public class NacionalidadesController : ControllerBase
    {
        private readonly NacionalidadService _NacionalidadService;

        public NacionalidadesController(NacionalidadService NacionalidadService)
        {
            _NacionalidadService = NacionalidadService;
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetNacionalidad()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseNacionalidad result = new ResponseNacionalidad();
            result.Response = new ResponseBodyNacionalidad();
            result.Response.data = new List<GetNacionalidadesModel>();

            var NacionalidadResponse = _NacionalidadService.GetNacionalidad();

            if (NacionalidadResponse != null && NacionalidadResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = NacionalidadResponse;
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
    }
}