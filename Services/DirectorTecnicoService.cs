using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class DTService
    {
        private string connection;
        public DTService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertDT(InsertDTModel dt)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = dt.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = dt.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pNacionalidad", SqlDbType = SqlDbType.Int, Value = dt.Nacionalidad });
                parametros.Add(new SqlParameter { ParameterName = "@pEdad", SqlDbType = SqlDbType.Int, Value = dt.Edad });
                parametros.Add(new SqlParameter { ParameterName = "@pidEquipo", SqlDbType = SqlDbType.Int, Value = dt.idEquipo });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = dt.UsuarioActualiza });




                DataSet ds = dac.Fill("sp_InsertDT", parametros);
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

        public List<GetDTModel> GetDT()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetDTModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetDirectorTecnico", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetDTModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
                            ApPaterno = row["ApPaterno"].ToString(),
                            Nacionalidad = row["Nacionalidad"].ToString(),
                            Edad = int.Parse(row["Edad"].ToString()),
                            idEquipo = row["IdEquipo"].ToString(),
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

        public string UpdateDT(UpdateDTModel dt)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = dt.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = dt.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = dt.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pNacionalidad", SqlDbType = SqlDbType.Int, Value = dt.Nacionalidad });
                parametros.Add(new SqlParameter { ParameterName = "@pEdad", SqlDbType = SqlDbType.Int, Value = dt.Edad });
                parametros.Add(new SqlParameter { ParameterName = "@pidEquipo", SqlDbType = SqlDbType.Int, Value = dt.idEquipo });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = dt.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdateDT", parametros);
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

        public string DeleteDT(DeleteDTModel dt)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = dt.Id });
                DataSet ds = dac.Fill("sp_DeleteDT", parametros);
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