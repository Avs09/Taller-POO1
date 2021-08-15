using System;
using config.c;

namespace config.m
{
    class Menu
    {
        public static ConfigurarEmpresa empresas;
        private byte opcion;
        public Menu()
        {
            do
            {
                Console.WriteLine("\n*** MENU CONFIGURAR EMPRESA ***\n");

                Console.WriteLine("1 para: CONFIGURAR NOMBRE DE EMPRESA");

                Console.WriteLine("2 para: CREAR 10 CLIENTES, 10 PRODUCTOS AUTOMATICAMENTE");

                catchFallos();
            }
            while(opcion != 1 && opcion != 2);

            Console.WriteLine("\nHAS SALIDO DEL MODULO CONFIGURAR EMPRESA");
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
                Console.WriteLine("\nEl numero {0} esta fuera de rango, por favor seleciona un numero entre 1 y 2", opcion);
            }
            catch(System.OverflowException)
            {
                Console.WriteLine("El numero es muy grande, por favor seleciona un numero entre 1 y 2");
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Error de formato, solo se admiten numeros");
            }
        }

        void validarOpcion()
        {
            if(opcion == 1)
            {
                Console.Write("\nNombre de la empresa: ");

                String empresa = Console.ReadLine();

                empresas = new ConfigurarEmpresa(empresa);

                Console.WriteLine("\nEl nombre '{0}' para empresa fue configurado correctamente", empresa);
            }
            else if(opcion == 2)
            {

            }

            else throw new ArgumentOutOfRangeException();
        }
    }
}