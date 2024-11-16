using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class EstadiosService
    {
        private string connection;
        public EstadiosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertEstadios(InsertEstadiosModel estadios)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<InsertEstadiosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = estadios.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pUbicacion", SqlDbType = SqlDbType.Int, Value = estadios.Ubicacion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = estadios.UsuarioActualiza });
          


                DataSet ds = dac.Fill("sp_InsertEstadios", parametros);
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

        public List<GetEstadiosModel> GetEstadios()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetEstadiosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetEstadios", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetEstadiosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre= row["Nombre"].ToString(),
                            Ubicacion= row["Ubicacion"].ToString(),
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

        public string UpdateEstadios(UpdateEstadiosModel estadios)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateEstadiosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = estadios.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = estadios.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pUbicacion", SqlDbType = SqlDbType.Int, Value = estadios.Ubicacion });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = estadios.UsuarioActualiza });



                DataSet ds = dac.Fill("sp_UpdateEstadios", parametros);
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

        public string DeleteEstadios(DeleteEstadiosModel estadios)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteEstadiosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = estadios.Id });
                DataSet ds = dac.Fill("sp_DeleteEstadios", parametros);
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