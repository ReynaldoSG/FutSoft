using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{

        public class ResponseEQ
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyEQ Response { get; set; }
    }

    public class ResponseBodyEQ
    {
        public List<GetEQModel> data { get; set; }
    }
    public class GetEQModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Campeonatos { get; set; }
        public string Ciudad { get; set; }
        public string IdLiga { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }


    }
    public class InsertEQModel
    {
         public string Nombre { get; set; }
        public int Campeonatos { get; set; }
        public string Ciudad { get; set; }
        public string IdLiga { get; set; }
        public int UsuarioActualiza { get; set; }
    }
    public class UpdateEQModel
    {
        public int Id { get; set; }        
        public string Nombre { get; set; }
        public int Campeonatos { get; set; }
        public int Ciudad { get; set; }
        public int IdLiga { get; set; }
        public int UsuarioActualiza { get; set; }
    }
    public class DeleteEQModel
    {
        public int Id { get; set; }
    }
}