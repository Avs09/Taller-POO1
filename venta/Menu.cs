using System;
using venta.s;

namespace venta.m
{
    class Menu
    {
        private byte opcion;
        public static Service serviciosVenta;
        public Menu()
        {
            serviciosVenta = new Service();

            do{
                Console.WriteLine($"\n*** BIENVENIDO/A AL MODULO DE VENTAS - EMPRESA {config.m.Menu.empresas.EMPRESA} ***\n");

                Console.WriteLine("1 para: REALIZAR VENTA");

                Console.WriteLine("2 para: BUSCAR FACTURA");

                Console.WriteLine("3 para: DESHABILITAR FACTURA");

                Console.WriteLine("4 para: HABILITAR FACTURA");

                Console.WriteLine("5 para: SALIR");

                catchFallos();
            }
            while(opcion != 5);

            Console.WriteLine("\nHAS SALIDO DEL MODULO VENTAS, VUELVE PRONTO");
        }

        void validarOpcion()
        {
            switch(opcion)
            {
                case 1:
                    serviciosVenta.insertVenta();
                break;

                case 2:
                    serviciosVenta.selectFactura();
                break;

                case 3:
                    serviciosVenta.deshabilitarFactura();
                break;

                case 4:
                    serviciosVenta.habilitarFactura();
                break;

                default:
                    if(opcion != 5) throw new ArgumentOutOfRangeException();
                break;
            }
        }

        void catchFallos()
        {
            try 
            {
                opcion = byte.Parse(Console.ReadLine());

                validarOpcion();
            }
            catch(System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("El numero {0} esta fuera de rango, por favor seleciona un numero entre 1 y 5", opcion);
            }
            catch(System.OverflowException)
            {
                Console.WriteLine("El numero es muy grande, por favor seleciona un numero entre 1 y 5");
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Error de formato, solo se admiten numeros");
            }
        }
    }
}