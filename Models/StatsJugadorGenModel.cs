using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

    public class ResponseSJG
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodySJG Response { get; set; }
    }

    public class ResponseBodySJG
    {
        public List<GetSJGModel> data { get; set; }
    }
    public class GetSJGModel
    {
        public string Jugador { get; set; }
        public string PartidosJugados { get; set; }
        public string GolesTotales { get; set; }
        public string AsistenciasTotales { get; set; }
        public string TarjetasAmarillas { get; set; }
        public string TarjetasRojas { get; set; }
        public string MinutosJugados { get; set; }
        public string Posicion { get; set; }


    }
}