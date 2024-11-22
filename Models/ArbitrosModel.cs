using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{

        public class ResponseArb
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyArb Response { get; set; }
    }

    public class ResponseBodyArb
    {
        public List<GetArbModel> data { get; set; }
    }
    public class GetArbModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public int TPartidos { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }


    }
    public class InsertArbModel
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public int TPartidos { get; set; }
        public int UsuarioActualiza { get; set; }
    }
    public class UpdateArbModel
    {
        public int Id { get; set; }        
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public int TPartidos { get; set; }
        public int UsuarioActualiza { get; set; }
    }
    public class DeleteArbModel
    {
        public int Id { get; set; }
    }
}