using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

    public class ResponseTemporadas
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodyTemporadas Response { get; set; }
    }

    public class ResponseBodyTemporadas
    {
        public List<GetTemporadasModel> data { get; set; }
    }

    public class InsertTemporadasModel
    {
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdLiga { get; set; }
        public int UsuarioActualiza { get; set; }

    }


    public class GetTemporadasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public string Liga { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        // public int Estatus { get; set; }
        public string UsuarioActualiza { get; set; }


    }



    public class UpdateTemporadasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdLiga { get; set; }
        public int UsuarioActualiza { get; set; }



    }

    public class DeleteTemporadasModel
    {
        public int Id { get; set; }
    }

}