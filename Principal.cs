using System;
using System.Collections.Generic;
namespace Taller_POO1
{
    class Principal
    {
        private config.m.Menu configEmpresa;
        private client.m.Menu moduloCliente;
        private prod.m.Menu moduloProducto;
        private venta.m.Menu moduloVenta;
        private byte opcion, opcion2;
        static void Main(string[] args)
        {
            Principal menuPrincipal = new Principal();

            menuPrincipal.Menu();
        }

        public Principal()
        {
            opcion2 = 1;

            prod.s.Service.listaProductos = new List<prod.p.Producto>();

            client.s.Service.listaClientes = new List<client.c.Cliente>();

            venta.s.Service.listaVentas = new List<venta.v.Venta>();
        }

        public void Menu()
        {
            do
            {
                configEmpresa = new config.m.Menu();
                
            }while(opcion2 != 1);

            while(opcion != 6)
            {
                Console.Write($"\n*** BIENVENIDO/A AL MENU PRINCIPAL - EMPRESA {config.m.Menu.empresas.EMPRESA} ***\n");

                Console.WriteLine("1 para ir al: MODULO DE CLIENTES");

                Console.WriteLine("2 para ir al: MODULO DE PRODUCTOS");

                Console.WriteLine("3 para ir al: MODULO DE VENTA");

                Console.WriteLine("4 para ir al: MODULO DE REPORTES");

                Console.WriteLine("5 para ir al: MODULO DE CONFIGURACIÓN");

                Console.WriteLine("6 para: SALIR");

                catchFallos();
            }

            Console.WriteLine("\nHAS SALIDO DEL MENU PRINCIPAL, VUELVE PRONTO");
        }

        void validarOpcion()
        {
            switch(opcion)
            {
                case 1:
                    moduloCliente = new client.m.Menu();
                break;

                case 2:
                    moduloProducto = new prod.m.Menu();
                break;

                case 3:
                    moduloVenta = new venta.m.Menu();
                break;

                case 4:
                break;

                case 5:
                    configEmpresa = new config.m.Menu();
                break;

                default:

                    if(opcion != 6) throw new ArgumentOutOfRangeException();
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
