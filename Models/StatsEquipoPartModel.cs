using System;
using System.Collections.Generic;
namespace marcatel_api.Models
{

    public class ResponseSEP
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public ResponseBodySEP Response { get; set; }
    }

    public class ResponseBodySEP
    {
        public List<GetSEPModel> data { get; set; }
    }

    public class InsertSEPModel
    {
        public int IdEquipo { get; set; }
        public int IdPartido { get; set; }
        public int GolesFav { get; set; }
        public int GolesCont { get; set; }
        public int TiroPuerta { get; set; }
        public int Faltas { get; set; }
        public int TAmarillas { get; set; }
        public int TRojas { get; set; }
        public int Corners { get; set; }
        public int Ofsides { get; set; }
        public int UsuarioActualiza { get; set; }

    }


    public class GetSEPModel
    {
        public int Id { get; set; }
        public string Equipo { get; set; }
        public string Partido { get; set; }
        public string GolesContra { get; set; }
        public string GolesFavor { get; set; }
        public string TirosPuerta { get; set; }
        public string TAmarilla { get; set; }
        public string TRojas { get; set; }
        public string Faltas { get; set; }
        public string Corners { get; set; }
        public string Ofsides { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioActualiza { get; set; }


    }



    public class UpdateSEPModel
    {
        public int Id { get; set; }
        public int IdEquipo { get; set; }
        public int IdPartido { get; set; }
        public int GolesContra { get; set; }
        public int GolesFav { get; set; }
        public int TiroPuerta { get; set; }
        public int Faltas { get; set; }
        public int TAmarillas { get; set; }
        public int TRojas { get; set; }
        public int Corners { get; set; }
        public int Ofsides { get; set; }
        public int UsuarioActualiza { get; set; }
    }

    public class DeleteSEPModel
    {
        public int Id { get; set; }
    }

}