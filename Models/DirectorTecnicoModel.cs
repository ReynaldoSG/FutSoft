using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{

        public class ResponseDT
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyDT Response { get; set; }
    }

    public class ResponseBodyDT
    {
        public List<GetDTModel> data { get; set; }
    }
    public class GetDTModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
         public string Nacionalidad { get; set; }
        public int Edad { get; set; }
        public string idEquipo { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }


    }
    public class InsertDTModel
    {
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
         public int Nacionalidad { get; set; }
        public int Edad { get; set; }
        public int idEquipo { get; set; }
        public int UsuarioActualiza { get; set; }
    }
    public class UpdateDTModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
         public int Nacionalidad { get; set; }
        public int Edad { get; set; }
        public int idEquipo { get; set; }
        public int UsuarioActualiza { get; set; }
    }
    public class DeleteDTModel
    {
        public int Id { get; set; }
    }
}