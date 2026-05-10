using Simulador_Cajero_Automatico;


class program
{

    static Cuenta InicioSesion(List<Cuenta> cuentas)
    {
        Console.WriteLine("Ingrese su numero de cuenta:");
        string numeroCuenta = Console.ReadLine(); 
        Console.WriteLine("Ingrese su contraseña:");
        string Pin = "";
        ConsoleKeyInfo tecla;

        do
        {
            tecla = Console.ReadKey(intercept: true);
             if (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Backspace)
            {
                Pin += tecla.KeyChar;
                Console.Write("*");
            }
            else if (tecla.Key == ConsoleKey.Backspace && Pin.Length > 0)
            {
                Pin = Pin.Substring(0, Pin.Length - 1);
                Console.Write("\b \b"); 
            }

        }while (tecla.Key != ConsoleKey.Enter);

        Console.WriteLine();


        foreach (Cuenta cuenta in cuentas)
        {

            if (numeroCuenta == cuenta.NumeroCuenta && Pin == cuenta.Pin)
            {
                Console.WriteLine($"Bienvenido {cuenta.Nombre}!");
                return cuenta;
            }


        }
        
        {
            Console.WriteLine("Numero de cuenta o PIN incorrecto. Intente de nuevo.");
            return null;
        }


    }

    static void RetirarDinero(Cuenta cuenta)
    {

        Console.WriteLine("\nSeleccione un monto a retirar:");
        Console.WriteLine("1. 100");
        Console.WriteLine("2. 200");
        Console.WriteLine("3. 300");
        Console.WriteLine("4. 500");
        Console.WriteLine("5. 1000");
        Console.WriteLine("6. Salir");


        if (!int.TryParse(Console.ReadLine(), out int opcion))
        {
            Console.WriteLine("ERROR");
            Console.WriteLine("Opcion no valida. Intente de nuevo.");
            return;
        }
        

        switch (opcion)
        {
            case 1:

                if(cuenta.Saldo >= 100)
                {
                    cuenta.Saldo -= 100;
                    Console.WriteLine("La transaccion de Q100 sido correctamente hecha");
                    cuenta.HistorialTransacciones.Add(new Transaccion("Retiro", 100.00m, DateTime.Now, cuenta.Saldo, "Retiro en cajero"));

                }
                else
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Saldo insuficiente");
                }

                break;

            case 2:

                if (cuenta.Saldo >= 200)
                {
                    cuenta.Saldo -= 200;
                    Console.WriteLine("La transaccion de Q200 sido correctamente hecha");
                    cuenta.HistorialTransacciones.Add(new Transaccion("Retiro", 200.00m, DateTime.Now, cuenta.Saldo, "Retiro en cajero"));

                }
                else
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Saldo insuficiente");
                }

                break;
            case 3:

                if (cuenta.Saldo >= 300)
                {
                    cuenta.Saldo -= 300;
                    Console.WriteLine("La transaccion de Q300 sido correctamente hecha");
                    cuenta.HistorialTransacciones.Add(new Transaccion("Retiro", 300.00m, DateTime.Now, cuenta.Saldo, "Retiro en cajero"));

                }
                else
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Saldo insuficiente");
                }

                break;

            case 4:

                if (cuenta.Saldo >= 500)
                {
                    cuenta.Saldo -= 500;
                    Console.WriteLine("La transaccion de Q500 sido correctamente hecha");
                    cuenta.HistorialTransacciones.Add(new Transaccion("Retiro", 500.00m, DateTime.Now, cuenta.Saldo, "Retiro en cajero"));

                }
                else
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Saldo insuficiente");
                }

                break;
            case 5:

                if (cuenta.Saldo >= 1000)
                {
                    cuenta.Saldo -= 1000;
                    Console.WriteLine("La transaccion de Q1000 sido correctamente hecha");
                    cuenta.HistorialTransacciones.Add(new Transaccion("Retiro", 1000.00m, DateTime.Now, cuenta.Saldo, "Retiro en cajero"));

                }
                else
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Saldo insuficiente");
                }

                break;
            case 6:

                Console.WriteLine("Volviendo al menu...");
                break;
        }


    }

    static void DepsotirarDinero(Cuenta cuenta)
    {

        Console.WriteLine("Ingrese el monto a depositar a su cuenta:");
        if (!decimal.TryParse(Console.ReadLine(), out decimal montoDeposito))
        {
            Console.WriteLine("Monto no valido. Ingrese un numero.");
            return;
        }
        if (montoDeposito <= 0)
        {
            Console.WriteLine("ERROR");
            Console.WriteLine("Monto de deposito no valido. Intente de nuevo.");
            return;
        }
        else { 
            cuenta.Saldo += montoDeposito;
        Console.WriteLine($"La transaccion de {montoDeposito:C} sido correctamente hecha");
        cuenta.HistorialTransacciones.Add(new Transaccion("Deposito", montoDeposito, DateTime.Now, cuenta.Saldo, "Deposito en ventanilla"));
        }
    }

    static void RealizarTransferencia(Cuenta cuenta, List<Cuenta> cuentas)
    {

        Console.WriteLine("Ingrese el numero de cuenta del destinatario:");
        string numeroCuentaDestinatario = Console.ReadLine();

        bool CuentaT_Encontrada = false;
        bool MismaCuentaT = false;


        foreach (Cuenta cuentaTercero in cuentas)
        {
            if (numeroCuentaDestinatario == cuentaTercero.NumeroCuenta && numeroCuentaDestinatario != cuenta.NumeroCuenta)
            {
                CuentaT_Encontrada = true;

                Console.WriteLine($"Le transferira a {cuentaTercero.Nombre}");

                Console.WriteLine("Ingrese el monto a transferir:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal montoTransferencia))
                {
                    Console.WriteLine("Monto no valido. Ingrese un numero.");
                    return;
                }

                if (montoTransferencia <= 0)
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Monto de transferencia no valido. Intente de nuevo.");
                    return;
                }

                if (cuenta.Saldo >= montoTransferencia)
                {
                    cuenta.Saldo -= montoTransferencia;
                    cuentaTercero.Saldo += montoTransferencia;
                    Console.WriteLine($"La transaccion de {montoTransferencia:C} sido correctamente hecha");
                    cuenta.HistorialTransacciones.Add(new Transaccion("Transferencia", montoTransferencia, DateTime.Now, cuenta.Saldo, $"Transferencia a {cuentaTercero.Nombre}"));
                }

                else
                {
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                }


            }
            else if (numeroCuentaDestinatario == cuenta.NumeroCuenta)
            {
                MismaCuentaT = true;


            }



        }

        if (!CuentaT_Encontrada && !MismaCuentaT)
        {
            Console.WriteLine("Numero de cuenta destinatario no encontrado. Intente de nuevo.");
        }
        else if (MismaCuentaT)
        {
            Console.WriteLine("No se puede transferir a la misma cuenta. Intente de nuevo.");
        }


    }


    static void HistorialTransacciones(Cuenta cuenta)
    {
        Console.WriteLine("\nHistorial de Transacciones:");

        foreach(Transaccion transaccion in cuenta.HistorialTransacciones)
        {
            Console.WriteLine($"{transaccion.Fecha}: {transaccion.TipoTransaccion} de {transaccion.Monto:C}. Saldo resultante: {transaccion.SaldoResultante:C}. Descripción: {transaccion.Descripcion}");
        }

    }

        static void MenuCajero(Cuenta cuenta, List<Cuenta> cuentas)
    {

        Console.WriteLine("Bienvenido al cajero automático");
        Console.WriteLine("Numero de cuenta" +cuenta.NumeroCuenta);

        bool salir = false;
        while (!salir)
        {

            Console.WriteLine("\nElige una opcion:");
            Console.WriteLine("1. Consultar Saldo");
            Console.WriteLine("2. Retirar dinero");
            Console.WriteLine("3. Depositar");
            Console.WriteLine("4. Realizar transferencia");
            Console.WriteLine("5. Ver historial de transacciones");
            Console.WriteLine("6. Salir");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.WriteLine("ERROR");
                Console.WriteLine("Opcion no valida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {

                case 1:
                    Console.WriteLine($"Su saldo actual es: {cuenta.Saldo:C}");
                    Console.WriteLine($"Su cuenta esta: {cuenta.EstadoCuenta}");

                    break;
                case 2:
                    Console.WriteLine("Retirar dinero");

                    if(cuenta.EstadoCuenta == "Activa")
                    {
                        RetirarDinero(cuenta);
                    }
                    else
                    {
                        Console.WriteLine("Su cuenta no esta activa");
                    }

                        break;
                case 3:
                    Console.WriteLine("Depositar");

                    if (cuenta.EstadoCuenta == "Activa")
                    {
                        DepsotirarDinero(cuenta);
                    }
                    else
                    {
                        Console.WriteLine("Su cuenta no esta activa");
                    }


                    break;
                case 4:
                    Console.WriteLine("Transferencia");

                    if (cuenta.EstadoCuenta == "Activa")
                    {
                        RealizarTransferencia(cuenta, cuentas);
                    }
                    else
                    {
                        Console.WriteLine("Su cuenta no esta activa");
                    }

                    break;
                case 5:
                    Console.WriteLine("Historial de tansacciones");
                    HistorialTransacciones(cuenta);

                    break;
                case 6:
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    Console.WriteLine(" ");
                    Environment.Exit(0);
                    break;



            }


        }






    }

    static void Main(string[] args)
    {

        // CLista de cuentas

        List<Cuenta> cuentas = new List<Cuenta>()
        {

            new Cuenta("123456789", "Juan Perez", "1234", 100.00m, "Activa"),
            new Cuenta("987654321", "Maria Lopez", "5678", 2500.00m, "Activa"),
            new Cuenta("555555555", "Carlos Sanchez", "4321", 500.00m, "Activa"),
            new Cuenta("111111111", "Ana Gomez", "8765", 1500.00m, "Activa"),
            new Cuenta("222222222", "Luis Ramirez", "2468", 3000.00m, "Activa"),
            new Cuenta("333333333", "Sofia Torres", "1357", 750.00m, "Activa"),
            new Cuenta("444444444", "Diego Fernandez", "8642", 2000.00m, "Activa") 


        };

        // Historial de transacciones pasadas 

        cuentas[0].HistorialTransacciones.Add(new Transaccion("Deposito", 500.00m, new DateTime(2026, 1, 15), 1500.00m, "Deposito en ventanilla"));
        cuentas[0].HistorialTransacciones.Add(new Transaccion("Retiro", 200.00m, new DateTime(2026, 2, 20), 1300.00m, "Retiro en cajero"));
        cuentas[0].HistorialTransacciones.Add(new Transaccion("Retiro", 100.00m, new DateTime(2026, 3, 5), 1200.00m, "Pago de servicio"));

        cuentas[1].HistorialTransacciones.Add(new Transaccion("Deposito", 1000.00m, new DateTime(2026, 2, 10), 3500.00m, "Deposito en ventanilla"));
        cuentas[1].HistorialTransacciones.Add(new Transaccion("Retiro", 500.00m, new DateTime(2026, 3, 25), 3000.00m, "Retiro en cajero"));
        cuentas[1].HistorialTransacciones.Add(new Transaccion("Retiro", 200.00m, new DateTime(2026, 4, 17), 2800.00m, "Pago de servicio"));

        cuentas[2].HistorialTransacciones.Add(new Transaccion("Deposito", 300.00m, new DateTime(2026, 2, 5), 800.00m, "Deposito en ventanilla"));
        cuentas[2].HistorialTransacciones.Add(new Transaccion("Retiro", 100.00m, new DateTime(2026, 3, 15), 700.00m, "Retiro en cajero"));
        cuentas[2].HistorialTransacciones.Add(new Transaccion("Retiro", 50.00m, new DateTime(2026, 2, 28), 650.00m, "Pago de servicio"));

        cuentas[3].HistorialTransacciones.Add(new Transaccion("Deposito", 700.00m, new DateTime(2026, 3, 20), 2200.00m, "Deposito en ventanilla"));
        cuentas[3].HistorialTransacciones.Add(new Transaccion("Retiro", 300.00m, new DateTime(2026, 3, 30), 1900.00m, "Retiro en cajero"));
        cuentas[3].HistorialTransacciones.Add(new Transaccion("Retiro", 100.00m, new DateTime(2026, 3, 10), 1800.00m, "Pago de servicio"));

        cuentas[4].HistorialTransacciones.Add(new Transaccion("Deposito", 1500.00m, new DateTime(2026, 1, 25), 4500.00m, "Deposito en ventanilla"));
        cuentas[4].HistorialTransacciones.Add(new Transaccion("Retiro", 1000.00m, new DateTime(2026, 1, 5), 3500.00m, "Retiro en cajero"));
        cuentas[4].HistorialTransacciones.Add(new Transaccion("Retiro", 500.00m, new DateTime(2026, 2, 15), 3000.00m, "Pago de servicio"));

        cuentas[5].HistorialTransacciones.Add(new Transaccion("Deposito", 400.00m, new DateTime(2026, 3, 10), 1150.00m, "Deposito en ventanilla"));
        cuentas[5].HistorialTransacciones.Add(new Transaccion("Retiro", 200.00m, new DateTime(2026, 4, 20), 950.00m, "Retiro en cajero"));
        cuentas[5].HistorialTransacciones.Add(new Transaccion("Retiro", 100.00m, new DateTime(2026, 4, 30), 850.00m, "Pago de servicio"));


        Cuenta usuarioActual = InicioSesion(cuentas);


        if (usuarioActual != null)
        {
            MenuCajero(usuarioActual, cuentas);

        }
        else
        {
            Console.WriteLine("No se pudo iniciar sesión. Por favor, intente nuevamente.");
        }




    }

}









