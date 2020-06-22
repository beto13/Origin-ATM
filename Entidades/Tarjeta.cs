using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarjeta
    {
        public int IdTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
        public string Pin { get; set; }
        public int Intentos { get; set; }
        public bool Bloquedo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Saldo { get; set; }

        public Tarjeta()
        {

        }
    }
}
