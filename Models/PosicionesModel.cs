using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{
   public class ResponsePosiciones
   {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyPosiciones Response { get; set; }
   }

   public class ResponseBodyPosiciones
   {
        public List<GetPosicionesModel> data { get; set; }
   }

   public class GetPosicionesModel
   {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
   }

   public class InsertPosicionesModel
   {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioActualiza { get; set; }
   }

   public class UpdatePosicionesModel
   {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioActualiza { get; set; }
   }

       public class DeletePosicionesModel
    {
        public int Id { get; set; }
    }
}