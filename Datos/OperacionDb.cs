using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class OperacionDb: ConexionDb
    {
        private SqlCommand cmd = null;

        public int RegistrarOperacion(Operacion objOperacion)
        {
            int respuesta = 0;

            try
            {
                if (Conectar())
                {
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SpOperacionRegistrar";
                    cmd.CommandTimeout = 180;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@idTarjeta", objOperacion.IdTarjeta);
                    cmd.Parameters.AddWithValue("@tipoOperacion", objOperacion.TipoOperacion);
                    cmd.Parameters.AddWithValue("@fecha", objOperacion.Fecha);
                    cmd.Parameters.AddWithValue("@monto", objOperacion.Monto);
                    
                    respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception Ex)
            {
                respuesta = 0;
                throw new Exception("Error al registrar operación.", Ex);
            }
            finally
            {
                conn.Close();
            }

            return respuesta;
        }

        public Operacion ConsultarOperacion(int id)
        {
            Operacion objOperacion = null;
            try
            {
                if (Conectar())
                {
                    cmd = new SqlCommand();
                    SqlDataReader dr = null;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SpConsultarOperacion";
                    cmd.CommandTimeout = 180;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@idOperacion", id);
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            objOperacion = new Operacion();
                            objOperacion.IdOperacion = Convert.ToInt32(dr["IdOperacion"]);
                            objOperacion.IdTarjeta = Convert.ToInt32(dr["IdTarjeta"]);
                            objOperacion.Fecha =Convert.ToDateTime(dr["Fecha"]);
                            objOperacion.Monto = Convert.ToDecimal(dr["Monto"]);
                            objOperacion.TipoOperacion =(dr["Monto"].ToString());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al validar PIN.", Ex);
            }
            finally
            {
                conn.Close();
            }

            return objOperacion;
        }
    }
}
