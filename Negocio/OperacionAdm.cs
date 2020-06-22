using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class OperacionAdm
    {
        OperacionDb objDb = new OperacionDb();

        public int RegistrarOperacion(Operacion objOperacion)
        {
            return objDb.RegistrarOperacion(objOperacion);
        }

        public Operacion ConsultarOperacion(int id )
        {
            return objDb.ConsultarOperacion(id);
        }
    }
}
