using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class JugadoresService
    {
        private string connection;
        public JugadoresService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


 public string InsertJugadores(InsertJugadoresModel jugadores)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = jugadores.Nombre });
        parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = jugadores.ApPaterno });
        parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = SqlDbType.VarChar, Value = jugadores.ApMaterno });
        parametros.Add(new SqlParameter { ParameterName = "@pEdad", SqlDbType = SqlDbType.Int, Value = jugadores.Edad });
        parametros.Add(new SqlParameter { ParameterName = "@pPosicion", SqlDbType = SqlDbType.Int, Value = jugadores.Posicion });
        parametros.Add(new SqlParameter { ParameterName = "@pEquipo", SqlDbType = SqlDbType.Int, Value = jugadores.Equipo });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = jugadores.UsuarioActualiza });

        // Llamando al procedimiento almacenado
        DataSet ds = dac.Fill("sp_InsertJugadores", parametros);

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

        public List<GetJugadoresModel> GetJugadores()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetJugadoresModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetJugadores", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetJugadoresModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre= row["Nombre"].ToString(),
                            ApPaterno= row["ApPaterno"].ToString(),
                            ApMaterno= row["ApMaterno"].ToString(),
                            Edad = int.Parse(row["Edad"].ToString()),
                             Posicion= row["Posicion"].ToString(),
                            Equipo= row["Equipo"].ToString(),
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

        public string UpdateJugadores(UpdateJugadoresModel jugadores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateJugadoresModel>();

            try
            {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = jugadores.Id });
        parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = jugadores.Nombre });
        parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = jugadores.ApPaterno });
        parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = SqlDbType.VarChar, Value = jugadores.ApMaterno });
        parametros.Add(new SqlParameter { ParameterName = "@pEdad", SqlDbType = SqlDbType.Int, Value = jugadores.Edad });
        parametros.Add(new SqlParameter { ParameterName = "@pPosicion", SqlDbType = SqlDbType.Int, Value = jugadores.Posicion });
        parametros.Add(new SqlParameter { ParameterName = "@pEquipo", SqlDbType = SqlDbType.Int, Value = jugadores.Equipo });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = jugadores.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateJugadores", parametros);
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




          


        public string DeleteJugadores(DeleteJugadoresModel jugadores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteJugadoresModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = jugadores.Id });
                DataSet ds = dac.Fill("sp_DeleteJugadores", parametros);
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