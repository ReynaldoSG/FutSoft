using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

  public class ResponseEstadios
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyEstadios Response { get; set; }
    }

    public class ResponseBodyEstadios
    {
        public List<GetEstadiosModel> data { get; set; }
    }

public class InsertEstadiosModel
    {
        public string Nombre { get; set; }
        public int Ubicacion { get; set; }
        public int UsuarioActualiza { get; set; }
         
    }


    public class GetEstadiosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }
        

    }

    

    public class UpdateEstadiosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Ubicacion { get; set; }
        public int UsuarioActualiza { get; set; }
        
        

    }

    public class DeleteEstadiosModel
    {
        public int Id { get; set; }
    }

}