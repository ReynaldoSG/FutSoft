using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

  public class ResponsePartidos
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyPartidos Response { get; set; }
    }

    public class ResponseBodyPartidos
    {
        public List<GetPartidosModel> data { get; set; }
    }

public class InsertPartidosModel
    {
        public int EquipoLocal { get; set; }
        public int EquipoVisitante { get; set; }
        public int Estadio { get; set; }
        public int Temporada { get; set; }
        public int MarcadorLocal { get; set; }
        public int MarcadorVisitante { get; set; }
         public string FechaPartido { get; set; }
        public int UsuarioActualiza { get; set; }
         
    }


    public class GetPartidosModel
    {
        public int Id { get; set; }
          public int EquipoLocal { get; set; }
        public int EquipoVisitante { get; set; }
        public string Estadio { get; set; }
        public string Temporada { get; set; }
        public int MarcadorLocal { get; set; }
        public int MarcadorVisitante { get; set; }
        public string FechaPartido { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }
        

    }

    

    public class UpdatePartidosModel
    {
        public int Id { get; set; }
          public int EquipoLocal { get; set; }
        public int EquipoVisitante { get; set; }
        public int Estadio { get; set; }
        public int Temporada { get; set; }
        public int MarcadorLocal { get; set; }
        public int MarcadorVisitante { get; set; }
           public string FechaPartido { get; set; }
        public int UsuarioActualiza { get; set; }
        
        

    }

    public class DeletePartidosModel
    {
        public int Id { get; set; }
    }

}