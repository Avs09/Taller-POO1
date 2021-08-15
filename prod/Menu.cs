using System;
using prod.s;

namespace prod.m
{
    class Menu
    {
        private byte opcion;
        public static Service serviciosProducto;
        public Menu()
        {
            serviciosProducto = new Service();

            do{
                Console.WriteLine($"\n*** BIENVENIDO/A AL MODULO DE PRODUCTOS - EMPRESA {config.m.Menu.empresas.EMPRESA} ***\n");

                Console.WriteLine("1 para: CREAR PRODUCTO");

                Console.WriteLine("2 para: BUSCAR PRODUCTO");

                Console.WriteLine("3 para: MODIFICAR PRODUCTO");

                Console.WriteLine("4 para: ELIMINAR PRODUCTO");

                Console.WriteLine("5 para: SALIR");

                catchFallos();
            }
            while(opcion != 5);

            Console.WriteLine("\nHAS SALIDO DEL MODULO PRODUCTOS, VUELVE PRONTO");
        }

        void validarOpcion()
        {
            switch(opcion)
            {
                case 1:
                    serviciosProducto.insertProducto();
                break;

                case 2:
                    serviciosProducto.selectProducto();
                break;

                case 3:
                    serviciosProducto.updateProducto();
                break;

                case 4:
                    serviciosProducto.deleteProducto();
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