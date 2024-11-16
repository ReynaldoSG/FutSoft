using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

  public class ResponseLiga
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyLiga Response { get; set; }
    }

    public class ResponseBodyLiga
    {
        public List<GetLigaModel> data { get; set; }
    }

public class InsertLigaModel
    {
        public string Nombre { get; set; }
        public int Ubicacion { get; set; }
        public string Categorias { get; set; }
        
        public int UsuarioActualiza { get; set; }
         
    }


    public class GetLigaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Categorias { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }
        

    }

    

    public class UpdateLigaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Ubicacion { get; set; }
        public string Categorias { get; set; }
        public int UsuarioActualiza { get; set; }
        
        

    }

    public class DeleteLigaModel
    {
        public int Id { get; set; }
    }

}