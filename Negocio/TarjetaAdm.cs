using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class TarjetaAdm
    {
        TarjetaDb objDb = new TarjetaDb();

        public Tarjeta ValidarTarjeta(string numeroTarjeta)
        {
            return objDb.ValidarTarjeta(numeroTarjeta);
        }

        public Tarjeta BuscarTarjeta(int idTarjeta)
        {
            return objDb.BuscarTarjeta(idTarjeta);
        }

        public bool ActualizarTarjeta(string operacion, int IdTarjeta, string parametro)
        {
            return objDb.ActualizarTarjeta(operacion, IdTarjeta, parametro);
        }

        public int Retirar(int IdTarjeta, int monto)
        {
            return objDb.Retirar(IdTarjeta, monto);
        }
    }
}
