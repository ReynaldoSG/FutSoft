using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

    public class ResponseSJG
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodySJG Response { get; set; }
    }

    public class ResponseBodySJG
    {
        public List<GetSJGModel> data { get; set; }
    }

    public class InsertSJGModel
    {
        public string Nombre { get; set; }
        public int Ubicacion { get; set; }
        public int UsuarioActualiza { get; set; }

    }


    public class GetSJGModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }


    }



    public class UpdateSJGModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Ubicacion { get; set; }
        public int UsuarioActualiza { get; set; }



    }

    public class DeleteSJGModel
    {
        public int Id { get; set; }
    }

}