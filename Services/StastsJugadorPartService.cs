using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class StatJugPartService
    {
        private string connection;
        public StatJugPartService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }


/*  public string InsertStatJugPart(InsertStatJugPartModel statJugPart)
{
    ArrayList parametros = new ArrayList();
    ConexionDataAccess dac = new ConexionDataAccess(connection);

    try
    {
        // Agregando los parámetros de inserción
        parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = StatJugPart.Nombre });
        parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = StatJugPart.Descripcion });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = StatJugPart.UsuarioActualiza });
        DataSet ds = dac.Fill("sp_InsertStatJugPart", parametros);

        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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

    // Retorno por defecto
    return "Error: Ocurrió un problema al insertar la unidad de medida."; // Valor por defecto en caso de fallo
} */

        public List<GetStatJugPartModel> GetStatJugPart()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetStatJugPartModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetStatJugadorPart", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetStatJugPartModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Jugador = row["Jugador"].ToString(),
                            Goles =int.Parse(row["Goles"].ToString()),
                            Asistencias = int.Parse(row["Asistencias"].ToString()),
                            TAmarilla = int.Parse(row["T_Amarilla"].ToString()),
                            TRoja = int.Parse(row["T_Roja"].ToString()),
                            Minutos = int.Parse(row["MinJugados"].ToString()),
                            Posicion = row["Posicion"].ToString(),
                            Partido = row["Partido"].ToString(),
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

/*         public string UpdateStatJugPart(UpdateStatJugPartModel StatJugPart)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<UpdateStatJugPartModel>();

            try
            {
        parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.VarChar, Value = StatJugPart.Id });
        parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = StatJugPart.Nombre });
        parametros.Add(new SqlParameter { ParameterName = "@pDescripcion", SqlDbType = SqlDbType.VarChar, Value = StatJugPart.Descripcion });
        parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = StatJugPart.UsuarioActualiza });


                DataSet ds = dac.Fill("sp_UpdateStatJugPart", parametros);
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
        } */




          

/* 
        public string DeleteStatJugPart(DeleteStatJugPartModel StatJugPart)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<DeleteStatJugPartModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = StatJugPart.Id });
                DataSet ds = dac.Fill("sp_DeleteStatJugPart", parametros);
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
        } */


    }
}