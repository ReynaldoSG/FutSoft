using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class StatsEquipoPartService
    {
        private string connection;
        public StatsEquipoPartService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertSEP(InsertSEPModel sep)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertSEPModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pIdEquipo", SqlDbType = SqlDbType.Int, Value = sep.IdEquipo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdPartido", SqlDbType = SqlDbType.Int, Value = sep.IdPartido });
                parametros.Add(new SqlParameter { ParameterName = "@pGolesFav", SqlDbType = SqlDbType.Int, Value = sep.GolesFav });
                parametros.Add(new SqlParameter { ParameterName = "@pGolesCont", SqlDbType = SqlDbType.Int, Value = sep.GolesCont });
                parametros.Add(new SqlParameter { ParameterName = "@pTiroPuerta", SqlDbType = SqlDbType.Int, Value = sep.TiroPuerta });
                parametros.Add(new SqlParameter { ParameterName = "@pFaltas", SqlDbType = SqlDbType.Int, Value = sep.Faltas });
                parametros.Add(new SqlParameter { ParameterName = "@pTAmarillas", SqlDbType = SqlDbType.Int, Value = sep.TAmarillas });
                parametros.Add(new SqlParameter { ParameterName = "@pTRojas", SqlDbType = SqlDbType.Int, Value = sep.TRojas });
                parametros.Add(new SqlParameter { ParameterName = "@pCorners", SqlDbType = SqlDbType.Int, Value = sep.Corners });
                parametros.Add(new SqlParameter { ParameterName = "@pOfsides", SqlDbType = SqlDbType.Int, Value = sep.Ofsides });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = sep.UsuarioActualiza });
                DataSet ds = dac.Fill("sp_InsertStatsEquipoPart", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        public List<GetSEPModel> GetSEP()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetSEPModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetStatEquipoPart", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetSEPModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Equipo = row["Equipo"].ToString(),
                            Partido = row["Partido"].ToString(),
                            GolesContra = row["GolesContra"].ToString(),
                            GolesFavor = row["GolesFavor"].ToString(),
                            TirosPuerta = row["TirosPuerta"].ToString(),
                            TAmarilla = row["TAmarilla"].ToString(),
                            TRojas = row["TRojas"].ToString(),
                            Faltas = row["Faltas"].ToString(),
                            Corners = row["Corners"].ToString(),
                            Ofsides = row["Ofsides"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            FechaActualiza = row["FechaActualiza"].ToString(),
                            UsuarioActualiza = row["UsuarioActualiza"].ToString()

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

        public string UpdateSEP(UpdateSEPModel sep)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateSEPModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = sep.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pIdEquipo", SqlDbType = SqlDbType.Int, Value = sep.IdEquipo });
                parametros.Add(new SqlParameter { ParameterName = "@pIdPartido", SqlDbType = SqlDbType.Int, Value = sep.IdPartido });
                parametros.Add(new SqlParameter { ParameterName = "@pGolesContra", SqlDbType = SqlDbType.Int, Value = sep.GolesContra });
                parametros.Add(new SqlParameter { ParameterName = "@pGolesFavor", SqlDbType = SqlDbType.Int, Value = sep.GolesFav });
                parametros.Add(new SqlParameter { ParameterName = "@pTirosPuerta", SqlDbType = SqlDbType.Int, Value = sep.TiroPuerta });
                parametros.Add(new SqlParameter { ParameterName = "@pTAmarilla", SqlDbType = SqlDbType.Int, Value = sep.TAmarillas });
                parametros.Add(new SqlParameter { ParameterName = "@pTRojas", SqlDbType = SqlDbType.Int, Value = sep.TRojas });
                parametros.Add(new SqlParameter { ParameterName = "@pFaltas", SqlDbType = SqlDbType.Int, Value = sep.Faltas });
                parametros.Add(new SqlParameter { ParameterName = "@pCorners", SqlDbType = SqlDbType.Int, Value = sep.Corners });
                parametros.Add(new SqlParameter { ParameterName = "@pOfsides", SqlDbType = SqlDbType.Int, Value = sep.Ofsides });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = sep.UsuarioActualiza });



                DataSet ds = dac.Fill("sp_UpdateStatsEquipoPart", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    return "No se recibió ningún mensaje desde la base de datos";
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return "Error: " + ex.Message;
            }
        }

        // public string DeleteEstadios(DeleteEstadiosModel estadios)
        // {
        //     ArrayList parametros = new ArrayList();
        //     ConexionDataAccess dac = new ConexionDataAccess(connection);
        //     var lista = new List<DeleteEstadiosModel>();

        //     try
        //     {
        //         parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = estadios.Id });
        //         DataSet ds = dac.Fill("sp_DeleteEstadios", parametros);
        //         if (ds.Tables[0].Rows.Count > 0)
        //         {
        //             return ds.Tables[0].Rows[0]["Mensaje"].ToString();
        //         }
        //         else
        //         {
        //             return "No se recibió ningún mensaje desde la base de datos";
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.Write(ex.Message);
        //         return "Error: " + ex.Message;
        //     }
        // }


    }
}