using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{
   public class ResponseStatJugPart
   {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyStatJugPart Response { get; set; }
   }

   public class ResponseBodyStatJugPart
   {
        public List<GetStatJugPartModel> data { get; set; }
   }

   public class GetStatJugPartModel
   {
        public int Id { get; set; }
        public string Jugador { get; set; }
        public int Goles { get; set; }
        public int Asistencias{get;set;}
        public int TAmarilla{get; set;}
        public int TRoja{get;set;}
        public int Minutos{get;set;}
        public string Posicion{get;set;}
        public string Partido {get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
   }

   public class InsertStatJugPartModel
   {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioActualiza { get; set; }
   }

   public class UpdateStatJugPartModel
   {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioActualiza { get; set; }
   }

       public class DeleteStatJugPartModel
    {
        public int Id { get; set; }
    }
}