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
    public class SJGController : ControllerBase
    {
        private readonly StatsJugadorGenService _SJGService;

        public SJGController(StatsJugadorGenService sjgService)
        {
            _SJGService = sjgService;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpGet("Get")]
        public IActionResult GetStatsJugadoresGen()
        {
            var objectResponse = Helper.GetStructResponse();
            ResponseSJG result = new ResponseSJG();
            result.Response = new ResponseBodySJG();
            result.Response.data = new List<GetSJGModel>();

            var SJGResponse = _SJGService.GetSJG();

            if (SJGResponse != null && SJGResponse.Any())
            {
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Error = false;
                result.Success = true;
                result.Message = "Información obtenida con éxito.";

                result.Response.data = SJGResponse;
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