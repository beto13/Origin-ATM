using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
        public int IdOperacion { get; set; }
        public int IdTarjeta { get; set; }
        public string TipoOperacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        public Operacion()
        {

        }
    }
}
