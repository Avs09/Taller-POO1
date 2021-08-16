using System;
using System.Collections.Generic;
using venta.v;
using venta.f;
using System.Text.RegularExpressions;

namespace venta.s
{
    class Service : Factura
    {
        public static List<Venta> listaVentas;
        private String documento, producto;
        private int cantidad;
        private static int numFactura = 1;
        public void insertVenta()
        {
            String confirmar = "si";

            Boolean continuar = true;

            Console.WriteLine("\nHas selecionado el 1 (Realizar venta) por favor ingresa los siguientes datos");

            while(continuar)
            {    
                if(confirmar.Equals("si"))
                {
                    leerDatos();

                    if(Venta.validaciones(documento, cantidad, producto))
                    {
                        Venta.descontarCantProd(producto, cantidad);

                        listaVentas.Add(new Venta(documento, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), cantidad, numFactura, Venta.getValorTotal(producto, cantidad), producto, Venta.getValorP(producto), false));

                        Console.WriteLine("Numero de factura: " + numFactura);

                        numFactura++;
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                
                Console.WriteLine("\n¿Quiere realizar una venta? ");

                confirmar = Console.ReadLine();
            }
        }

        public void selectFactura()
        {
            String confirmar = "si";

            Boolean continuar = true;

            int numFacBusqueda;

            Console.WriteLine("\nHas selecionado el 2 (Buscar factura)");

            while(continuar)
            {    
                if(confirmar.Equals("si"))
                {
                    Console.Write("\nNumero de factura que quiere buscar: ");

                    numFacBusqueda = int.Parse(Console.ReadLine());

                    if(Venta.validarNumFact(numFacBusqueda, listaVentas) == false) Console.WriteLine($"\nEl numero de factura '{numFacBusqueda}' no existe");

                    else
                    {
                        if(Factura.getDeshabilitarF(listaVentas, numFacBusqueda) != true) Venta.getFacturaBusqueda(listaVentas, numFacBusqueda);

                        else Console.WriteLine("\nLa factura N°{0} esta deshabilitada ", numFacBusqueda);
                    }

                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                
                Console.WriteLine("\n¿Quiere buscar una factura? ");

                confirmar = Console.ReadLine();
            }
        }
        public void deshabilitarFactura()
        {
            String confirmar = "si";

            Boolean continuar = true;

            int numFacBusqueda;

            Console.WriteLine("\nHas selecionado el 3 (Deshabilitar factura)");

            while(continuar)
            {    
                if(confirmar.Equals("si"))
                {
                    Console.Write("\nNumero de factura que quiere deshabilitar: ");

                    numFacBusqueda = int.Parse(Console.ReadLine());

                    if(Venta.validarNumFact(numFacBusqueda, listaVentas) == false) Console.WriteLine($"\nEl numero de factura '{numFacBusqueda}' no existe");

                    else 
                    {
                        if(Factura.getDeshabilitarF(listaVentas, numFacBusqueda) != true) 
                        {
                            if(Factura.deshabFactura(numFacBusqueda, listaVentas)== false) break;
                        }
                        else Console.WriteLine("\nLa factura N°{0} ya esta deshabilitada ", numFacBusqueda);
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                
                Console.WriteLine("\n¿Quiere deshabilitar una factura? ");

                confirmar = Console.ReadLine();
            }
        }

        public void habilitarFactura()
        {
            String confirmar = "si";

            Boolean continuar = true;

            int numFacBusqueda;

            Console.WriteLine("\nHas selecionado el 4 (Habilitar factura)");

            while(continuar)
            {    
                if(confirmar.Equals("si"))
                {
                    Console.Write("\nNumero de factura que quiere habilitar: ");
                    
                    numFacBusqueda = int.Parse(Console.ReadLine());

                    if(Venta.validarNumFact(numFacBusqueda, listaVentas) == false) Console.WriteLine($"\nEl numero de factura '{numFacBusqueda}' no existe");

                    else 
                    {
                        if(Factura.getDeshabilitarF(listaVentas, numFacBusqueda) != false) 
                        {
                            if(Factura.habilitarFactura(numFacBusqueda, listaVentas) == false) break;
                        }
                        else Console.WriteLine("\nLa factura N°{0} ya esta habilitada ", numFacBusqueda);
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                
                Console.WriteLine("\n¿Quiere habilitar una factura? ");

                confirmar = Console.ReadLine();
            }
        }

        void leerDatos()
        {
            Console.Write("\nDocumento del cliente: ");

            documento = Console.ReadLine();

            Console.Write("Producto: ");

            producto = Console.ReadLine();

            Console.Write("Cantidad de productos: ");

            cantidad = int.Parse(Console.ReadLine());
        }
    }
}