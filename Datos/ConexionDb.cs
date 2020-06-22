using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ConexionDb
    {
        protected string connString = "Data Source =ENGUELBERT\\SQLEXPRESS; Initial Catalog = OriginATM; Integrated Security = True;";
        protected SqlConnection conn = null;

        public bool Conectar()
        {
            bool respuesta = false;
            try
            {
                conn = new SqlConnection(connString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    respuesta = true;
                }
                return respuesta;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al conectar a la base de datos.", Ex);
            }
        }

        public void Desconectar()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
