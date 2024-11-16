using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class LigaService
    {
        private string connection;
        public LigaService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


 public string InsertLiga(InsertLigaModel liga)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = liga.Nombre });
        parametros.Add(new SqlParameter { ParameterName = "@pUbicacion", SqlDbType = SqlDbType.Int, Value = liga.Ubicacion });
        parametros.Add(new SqlParameter { ParameterName = "@pCategorias", SqlDbType = SqlDbType.VarChar, Value = liga.Categorias });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = liga.UsuarioActualiza });

        // Llamando al procedimiento almacenado
        DataSet ds = dac.Fill("sp_InsertLiga", parametros);

        // Asegúrate de que hay al menos una tabla devuelta
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0]["Mensaje"].ToString(); // Retorna el mensaje del SP
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

    // Retorno por defecto
    return "Error: Ocurrió un problema al insertar la unidad de medida."; // Valor por defecto en caso de fallo
}

        public List<GetLigaModel> GetLiga()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetLigaModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetLiga", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetLigaModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre= row["Nombre"].ToString(),
                            Ubicacion= row["Ubicacion"].ToString(),
                            Categorias = row["Categorias"].ToString(),
                            FechaRegistro= row["FechaRegistro"].ToString(),
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

        public string UpdateLiga(UpdateLigaModel liga)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateLigaModel>();

            try
            {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = liga.Id });
        parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = liga.Nombre });
        parametros.Add(new SqlParameter { ParameterName = "@pUbicacion", SqlDbType = SqlDbType.Int, Value = liga.Ubicacion });
        parametros.Add(new SqlParameter { ParameterName = "@pCategorias", SqlDbType = SqlDbType.VarChar, Value = liga.Categorias });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = liga.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateLiga", parametros);
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




          


        public string DeleteLiga(DeleteLigaModel liga)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteLigaModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = liga.Id });
                DataSet ds = dac.Fill("sp_DeleteLiga", parametros);
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