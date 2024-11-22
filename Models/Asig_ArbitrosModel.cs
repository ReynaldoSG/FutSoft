using System;
using System.Collections.Generic;
namespace marcatel_api.Models

{

        public class ResponseAsigArb
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyAsigArb Response { get; set; }
    }

    public class ResponseBodyAsigArb
    {
        public List<GetAsigArbModel> data { get; set; }
    }
    public class GetAsigArbModel
    {
        public int Id { get; set; }
        public string Partido { get; set; }
        public string Arbitro { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }


    }
    public class InsertAsigArbModel
    {
        public int Partido { get; set; }
        public int Arbitro { get; set; }
        public int UsuarioActualiza { get; set; }
    }
    public class UpdateAsigArbModel
    {
        public int Id { get; set; }        
        public int Partido { get; set; }
        public int Arbitro { get; set; }
        public int UsuarioActualiza { get; set; }
    }
    public class DeleteAsigArbModel
    {
        public int Id { get; set; }
    }
}