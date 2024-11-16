using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class PartidosService
    {
        private string connection;
        public PartidosService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


 public string InsertPartidos(InsertPartidosModel partidos)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pEquipoLocal", SqlDbType = SqlDbType.Int, Value = partidos.EquipoLocal });
        parametros.Add(new SqlParameter { ParameterName = "@pEquipoVisitante", SqlDbType = SqlDbType.Int, Value = partidos.EquipoVisitante });
        parametros.Add(new SqlParameter { ParameterName = "@pEstadio", SqlDbType = SqlDbType.Int, Value = partidos.Estadio });
        parametros.Add(new SqlParameter { ParameterName = "@pTemporada", SqlDbType = SqlDbType.Int, Value = partidos.Temporada });
        parametros.Add(new SqlParameter { ParameterName = "@pMarcadorLocal", SqlDbType = SqlDbType.Int, Value = partidos.MarcadorLocal });
        parametros.Add(new SqlParameter { ParameterName = "@pMarcadorVisitante", SqlDbType = SqlDbType.Int, Value = partidos.MarcadorVisitante });
        parametros.Add(new SqlParameter { ParameterName = "@pFechaPartido", SqlDbType = SqlDbType.Date, Value = partidos.FechaPartido });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = partidos.UsuarioActualiza });

        // Llamando al procedimiento almacenado
        DataSet ds = dac.Fill("sp_InsertPartidos", parametros);

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

        public List<GetPartidosModel> GetPartidos()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetPartidosModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetPartidos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetPartidosModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            EquipoLocal = int.Parse(row["EquipoLocal"].ToString()),
                            EquipoVisitante = int.Parse(row["EquipoVisitante"].ToString()),
                            Estadio = row["Estadio"].ToString(),
                            Temporada = row["Temporada"].ToString(),
                            MarcadorLocal = int.Parse(row["MarcadorLocal"].ToString()),
                            MarcadorVisitante = int.Parse(row["MarcadorVisitante"].ToString()),
                            FechaPartido= row["FechaPartido"].ToString(),
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

        public string UpdatePartidos(UpdatePartidosModel partidos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdatePartidosModel>();

            try
            {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = partidos.Id });
        parametros.Add(new SqlParameter { ParameterName = "@pEquipoLocal", SqlDbType = SqlDbType.Int, Value = partidos.EquipoLocal });
        parametros.Add(new SqlParameter { ParameterName = "@pEquipoVisitante", SqlDbType = SqlDbType.Int, Value = partidos.EquipoVisitante });
        parametros.Add(new SqlParameter { ParameterName = "@pEstadio", SqlDbType = SqlDbType.Int, Value = partidos.Estadio });
        parametros.Add(new SqlParameter { ParameterName = "@pTemporada", SqlDbType = SqlDbType.Int, Value = partidos.Temporada });
        parametros.Add(new SqlParameter { ParameterName = "@pMarcadorLocal", SqlDbType = SqlDbType.Int, Value = partidos.MarcadorLocal });
        parametros.Add(new SqlParameter { ParameterName = "@pMarcadorVisitante", SqlDbType = SqlDbType.Int, Value = partidos.MarcadorVisitante });
        parametros.Add(new SqlParameter { ParameterName = "@pFechaPartido", SqlDbType = SqlDbType.Date, Value = partidos.FechaPartido });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = partidos.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdatePartidos", parametros);
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




          


        public string DeletePartidos(DeletePartidosModel partidos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeletePartidosModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = partidos.Id });
                DataSet ds = dac.Fill("sp_DeletePartidos", parametros);
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