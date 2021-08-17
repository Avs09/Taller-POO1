using System;
using report.s;

namespace report.m
{
    class Menu
    {
        private byte opcion;
        private static Service serviciosReporte;
        public Menu()
        {
            serviciosReporte = new Service();

            do{
                Console.WriteLine($"\n*** MODULO DE REPORTES - EMPRESA {config.m.Menu.empresas.EMPRESA} ***\n");

                Console.WriteLine("Menu\n1 para: LISTAR CLIENTES");

                Console.WriteLine("2 para: LISTAR PRODUCTO");

                Console.WriteLine("3 para: LISTAR FACTURAS");

                Console.WriteLine("4 para: SALIR");

                catchFallos();
            }
            while(opcion != 4);

            Console.WriteLine("\nHAS SALIDO DEL MODULO REPORTES, VUELVE PRONTO");
        }

        void validarOpcion()
        {
            switch(opcion)
            {
                case 1:
                    serviciosReporte.listarClientes();
                break;

                case 2:
                    serviciosReporte.listarProductos();
                break;

                case 3:
                    serviciosReporte.listarFacturas();
                break;

                default:
                    if(opcion != 4) throw new ArgumentOutOfRangeException();
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