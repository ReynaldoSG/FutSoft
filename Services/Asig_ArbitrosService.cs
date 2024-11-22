using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using marcatel_api.DataContext;
using marcatel_api.Models;
using System.Collections;

namespace marcatel_api.Services
{
    public class AsigArbService
    {
        private string connection;
        public AsigArbService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public string InsertAsigArb(InsertAsigArbModel asigarb)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pPartido", SqlDbType = SqlDbType.Int, Value = asigarb.Partido });
                parametros.Add(new SqlParameter { ParameterName = "@pArbitro", SqlDbType = SqlDbType.Int, Value = asigarb.Arbitro });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = asigarb.UsuarioActualiza });




                DataSet ds = dac.Fill("sp_InsertAsigArbitros", parametros);
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

        public List<GetAsigArbModel> GetAsigArbs()
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            var lista = new List<GetAsigArbModel>();
            try
            {
                DataSet ds = dac.Fill("sp_GetAsigArbitros", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GetAsigArbModel
                        {
                            Id = int.Parse(row["Id"].ToString()),
                            Partido = row["Partido"].ToString(),
                            Arbitro = row["Arbitro"].ToString(),
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

        public string UpdateAsigArb(UpdateAsigArbModel asigArbs)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = asigArbs.Id });
                parametros.Add(new SqlParameter { ParameterName = "@pPartido", SqlDbType = SqlDbType.Int, Value = asigArbs.Partido });
                parametros.Add(new SqlParameter { ParameterName = "@pArbitro", SqlDbType = SqlDbType.Int, Value = asigArbs.Arbitro });
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioActualiza", SqlDbType = SqlDbType.Int, Value = asigArbs.UsuarioActualiza });

                DataSet ds = dac.Fill("sp_UpdateAsigArbitros", parametros);
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

        public string DeleteAsigArbitros(DeleteAsigArbModel asigArbs)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = asigArbs.Id });
                DataSet ds = dac.Fill("sp_DeleteAsigArbitros", parametros);
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