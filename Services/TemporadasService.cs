using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class TemporadasService
    {
        private string connection;
        public TemporadasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertTemporadas(InsertTemporadasModel temp)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertTemporadasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = temp.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaInicio", SqlDbType = SqlDbType.DateTime, Value = temp.FechaInicio });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaFinal", SqlDbType = SqlDbType.DateTime, Value = temp.FechaFinal });
                parametros.Add(new SqlParameter { ParameterName = "@pIdLiga", SqlDbType = SqlDbType.Int, Value = temp.IdLiga });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = temp.UsuarioActualiza });



                DataSet ds = dac.Fill("sp_InsertTemporadas", parametros);
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

        public List<GetTemporadasModel> GetTemporadas()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetTemporadasModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetTemporadas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetTemporadasModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            FechaInicio = row["FechaInicio"].ToString(),
                            FechaFinal = row["FechaFinal"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            Liga = row["Liga"].ToString(),
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

        public string UpdateTemporadas(UpdateTemporadasModel temp)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateTemporadasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = temp.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = temp.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pIdLiga", SqlDbType = SqlDbType.Int, Value = temp.IdLiga });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = temp.UsuarioActualiza });



                DataSet ds = dac.Fill("sp_UpdateTemporadas", parametros);
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

        public string DeleteTemporadas(DeleteTemporadasModel temp)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteTemporadasModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = temp.Id });
                DataSet ds = dac.Fill("sp_DeleteTemporadas", parametros);
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


    }
}