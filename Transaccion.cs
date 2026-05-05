using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador_Cajero_Automatico
{
    internal class Transaccion
    {

        public string TipoTransaccion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SaldoResultante { get; set; }
        public string Descripcion { get; set; }



        public Transaccion(string tipoTransaccion, decimal monto, DateTime fecha, decimal saldoResultante, string descripcion)
        {
            TipoTransaccion = tipoTransaccion;
            Monto = monto;
            Fecha = fecha;
            SaldoResultante = saldoResultante;
            Descripcion = descripcion;
        }

    }
}
