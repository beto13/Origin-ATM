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
    public class TarjetaDb : ConexionDb
    {
        private SqlCommand cmd = null;

        public Tarjeta ValidarTarjeta(string numeroTarjeta)
        {
            Tarjeta objTarjeta = null;
            try
            {
                if (Conectar())
                {
                    cmd = new SqlCommand();
                    SqlDataReader dr = null;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SpTarjetaValidar";
                    cmd.CommandTimeout = 180;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@numeroTarjeta", numeroTarjeta);
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            objTarjeta = new Tarjeta();
                            objTarjeta.IdTarjeta = Convert.ToInt32(dr["IdTarjeta"]);
                            objTarjeta.NumeroTarjeta = dr["NumeroTarjeta"].ToString();
                            objTarjeta.Pin = dr["Pin"].ToString();
                            objTarjeta.FechaVencimiento =Convert.ToDateTime(dr["FechaVencimiento"].ToString());
                            objTarjeta.Bloquedo = Convert.ToBoolean(dr["Bloquedo"]);
                            objTarjeta.Intentos = Convert.ToInt32(dr["Intentos"]);
                            objTarjeta.Saldo = Convert.ToDecimal(dr["Saldo"]);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al validar Tarjeta.", Ex);
            }
            finally
            {
                conn.Close();
            }

            return objTarjeta;
        }

        public Tarjeta BuscarTarjeta(int idTarjeta)
        {
            Tarjeta objTarjeta = null;
            try
            {
                if (Conectar())
                {
                    cmd = new SqlCommand();
                    SqlDataReader dr = null;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SpTarjetaBuscar";
                    cmd.CommandTimeout = 180;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@idTarjeta", idTarjeta);
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            objTarjeta = new Tarjeta();
                            objTarjeta.IdTarjeta = Convert.ToInt32(dr["IdTarjeta"]);
                            objTarjeta.NumeroTarjeta = dr["NumeroTarjeta"].ToString();
                            objTarjeta.Pin = dr["Pin"].ToString();
                            objTarjeta.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"].ToString());
                            objTarjeta.Bloquedo = Convert.ToBoolean(dr["Bloquedo"]);
                            objTarjeta.Intentos = Convert.ToInt32(dr["Intentos"]);
                            objTarjeta.Saldo = Convert.ToDecimal(dr["Saldo"]);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al buscar Tarjeta.", Ex);
            }
            finally
            {
                conn.Close();
            }

            return objTarjeta;
        }

        public bool ActualizarTarjeta(string operacion, int IdTarjeta, string parametro)
        {
            bool respuesta = false;

            try
            {
                if (Conectar())
                {
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SpTarjetaEditar";
                    cmd.CommandTimeout = 180;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@IdTarjeta", IdTarjeta);
                    cmd.Parameters.AddWithValue("@operacion", operacion);
                    cmd.Parameters.AddWithValue("@parametro", parametro);
     
                    if (cmd.ExecuteNonQuery()>0)
                    {
                        respuesta = true;
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                respuesta = false;
                throw new Exception("Error al actualizar tarjeta.", Ex);
            }
            finally
            {
                conn.Close();
            }

            return respuesta;
        }

        public int Retirar(int IdTarjeta, int monto)
        {
            int respuesta = 0;
            cmd = new SqlCommand();
            SqlTransaction transaction=null;

            try
            {
                if (Conectar())
                {
                    cmd.Connection = conn;
                    transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SpTarjetaRetirar";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@IdTarjeta", IdTarjeta);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SpOperacionRegistrar";
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@idTarjeta", IdTarjeta);
                    cmd.Parameters.AddWithValue("@tipoOperacion", "Retiro");
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    respuesta= Convert.ToInt32(cmd.ExecuteScalar());

                    transaction.Commit();
                    cmd.Clone();
                 }
            }
            catch (Exception Ex)
            {
                transaction.Rollback();
                respuesta = 0;
                throw new Exception("Error al retirar.", Ex);
            }
            finally
            {
                conn.Close();
            }

            return respuesta;
        }
    }
}
