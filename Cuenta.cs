using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador_Cajero_Automatico
{
    internal class Cuenta
    {

        public string NumeroCuenta { get; set; }
        public string Nombre { get; set; }
        public string Pin { get; set; }
        public decimal Saldo { get; set; }
        public string EstadoCuenta { get; set; }
        public List<Transaccion> HistorialTransacciones { get; set; }


        public Cuenta(string numeroCuenta, string nombre, string pin, decimal saldo, string estadoCuenta)
        {
            NumeroCuenta = numeroCuenta;
            Nombre = nombre;
            Pin = pin;
            Saldo = saldo;
            EstadoCuenta = estadoCuenta;
            HistorialTransacciones = new List<Transaccion>();

        }

    }
}
