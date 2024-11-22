using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class EquiposService
    {
        private string connection;
        public EquiposService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertEQ(InsertEQModel eq)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = eq.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pCampeonatos", SqlDbType = SqlDbType.Int, Value = eq.Campeonatos });
                parametros.Add(new SqlParameter { ParameterName = "@pCiudad", SqlDbType = SqlDbType.Int, Value = eq.Ciudad });
                parametros.Add(new SqlParameter { ParameterName = "@pIdLiga", SqlDbType = SqlDbType.Int, Value = eq.IdLiga });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = eq.UsuarioActualiza });




                DataSet ds = dac.Fill("sp_InsertEquipos", parametros);
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

        public List<GetEQModel> GetEQ()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEQModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetEquipos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetEQModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            Campeonatos = int.Parse(row["Id"].ToString()),
                            Ciudad = row["Ciudad"].ToString(),
                            IdLiga = row["IdLiga"].ToString(),
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

        public string UpdateEQ(UpdateEQModel eq)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = eq.Id });
               parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = eq.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pCampeonatos", SqlDbType = SqlDbType.Int, Value = eq.Campeonatos });
                parametros.Add(new SqlParameter { ParameterName = "@pCiudad", SqlDbType = SqlDbType.Int, Value = eq.Ciudad });
                parametros.Add(new SqlParameter { ParameterName = "@pIdLiga", SqlDbType = SqlDbType.Int, Value = eq.IdLiga });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = eq.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdateEquipos", parametros);
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

        public string DeleteEQ(DeleteEQModel eq)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = eq.Id });
                DataSet ds = dac.Fill("sp_DeleteEquipos", parametros);
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