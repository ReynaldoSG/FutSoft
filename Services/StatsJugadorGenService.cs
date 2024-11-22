using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class StatsJugadorGenService
    {
        private string connection;
        public StatsJugadorGenService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


        public List<GetSJGModel> GetSJG()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetSJGModel>();
            try
            {
                DataSet ds = dac.Fill("sp_getStatJugadorGen", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetSJGModel
                        {
                            Jugador = row["Jugador"].ToString(),
                            PartidosJugados = row["PartidosJugados"].ToString(),
                            GolesTotales = row["GolesTotales"].ToString(),
                            AsistenciasTotales = row["AsistenciasTotales"].ToString(),
                            TarjetasAmarillas = row["TarjetasAmarillas"].ToString(),
                            TarjetasRojas = row["TarjetasRojas"].ToString(),
                            MinutosJugados = row["MinutosJugados"].ToString(),
                            Posicion = row["Posicion"].ToString()

                        });
                    }
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}