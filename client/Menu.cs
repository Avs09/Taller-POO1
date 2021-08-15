using System;
using client.s;
namespace client.m
{
    class Menu
    {
        private byte opcion;
        public static Service serviciosCliente;
        public Menu()
        {
            serviciosCliente = new Service();

            do{

                Console.WriteLine($"\n*** BIENVENIDO/A AL MODULO DE CLIENTE - EMPRESA {config.m.Menu.empresas.EMPRESA} ***\n");

                Console.WriteLine("1 para: CREAR CLIENTE");

                Console.WriteLine("2 para: BUSCAR CLIENTE");

                Console.WriteLine("3 para: MODIFICAR CLIENTE");

                Console.WriteLine("4 para: ELIMINAR CLIENTE");

                Console.WriteLine("5 para: SALIR");

                catchFallos();
            }
            while(opcion != 5);

            Console.WriteLine("\nHAS SALIDO DEL MODULO CLIENTES, VUELVE PRONTO");
        }

        void validarOpcion()
        {
            switch(opcion)
            {
                case 1:
                    serviciosCliente.insertCliente();
                break;

                case 2:
                    serviciosCliente.selectCliente();
                break;

                case 3:
                    serviciosCliente.updateCliente();
                break;

                case 4:
                    serviciosCliente.deleteCliente();
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