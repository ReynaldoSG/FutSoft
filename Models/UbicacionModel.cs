using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

    public class ResponseUbicacion
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyUbicacion Response { get; set; }
    }

    public class ResponseBodyUbicacion
    {
        public List<GetUbicacionesModel> data { get; set; }
    }

    public class InsertUbicacionesModel
    {
        public string Nombre { get; set; }
        public int UsuarioActualiza { get; set; }

    }


    public class GetUbicacionesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }


    }



    public class UpdateUbicacionesModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioActualiza { get; set; }



    }

    public class DeleteUbicacionesModel
    {
        public int Id { get; set; }
    }

}