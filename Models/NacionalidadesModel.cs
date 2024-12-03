using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

    public class ResponseNacionalidad
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyNacionalidad Response { get; set; }
    }

    public class ResponseBodyNacionalidad
    {
        public List<GetNacionalidadesModel> data { get; set; }
    }


    public class GetNacionalidadesModel
    {
        public int Id { get; set; }
        public string Nacionalidad { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }


    }



}