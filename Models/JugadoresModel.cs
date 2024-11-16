using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

  public class ResponseJugadores
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyJugadores Response { get; set; }
    }

    public class ResponseBodyJugadores
    {
        public List<GetJugadoresModel> data { get; set; }
    }

public class InsertJugadoresModel
    {
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public int Posicion { get; set; }
        public int Equipo { get; set; }
        public int UsuarioActualiza { get; set; }
         
    }


    public class GetJugadoresModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public string Posicion { get; set; }
        public string Equipo { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }
        

    }

    

    public class UpdateJugadoresModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Edad { get; set; }
        public int Posicion { get; set; }
        public int Equipo { get; set; }
        public int UsuarioActualiza { get; set; }
        
        

    }

    public class DeleteJugadoresModel
    {
        public int Id { get; set; }
    }

}