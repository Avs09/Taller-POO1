using System;
using venta.v;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace venta.f
{
    class Factura
    {
        protected static void encabezado(String documento, double valorTotal, int numFactura, String codigo)
        {
            Console.WriteLine("N° factura: " + numFactura);

            Console.WriteLine("Documento: " + documento);

            Console.WriteLine("Codigo producto: " + codigo);

            Console.WriteLine("Precio total: $" + valorTotal);
        }

        protected static void detalle(String producto, int cantidad, double precio, String fecha)
        {
            Console.WriteLine("Fecha: " + fecha);

            Console.WriteLine("Producto: " + producto);

            Console.WriteLine("Precio del producto: $" + precio);

            Console.WriteLine("Cantidad: " + cantidad);
        }

        protected static Boolean deshabFactura(int numFactura, List<Venta> listaVentas)
        {
            String confirmar = "";

            while(confirmar.Equals("si")== false)
            {
                Console.Write($"\n¿Esta seguro de deshabilitar la factura '{numFactura}'? ");

                confirmar = Console.ReadLine();

                var query = listaVentas.Where(factura => factura.NUMFACTURA == numFactura).ToList();

                if(confirmar.Equals("si"))
                {
                    foreach(var fact in query)
                    {
                        fact.DESHABILITAR = true;
                    }

                    Console.WriteLine($"\nLa factura N°'{numFactura}' fue deshabilitada correctamente");
                }

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else if(confirmar.Equals("no"))  return false;
                
                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
            }
            return true;
        }

        protected static Boolean habilitarFactura(int numFactura, List<Venta> listaVentas)
        {
            String confirmar = "";

            while(confirmar.Equals("si")== false)
            {
                Console.Write($"\n¿Esta seguro de habilitar la factura '{numFactura}'? ");

                confirmar = Console.ReadLine();

                var query = listaVentas.Where(factura => factura.NUMFACTURA == numFactura).ToList();

                if(confirmar.Equals("si"))
                {
                    foreach(var fact in query)
                    {
                        fact.DESHABILITAR = false;
                    }

                    Console.WriteLine($"\nLa factura N°'{numFactura}' fue habilitada correctamente");
                }

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else if(confirmar.Equals("no"))  return false;
                
                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
            }

            return true;
        }

        protected static Boolean getDeshabilitarF(List<Venta> listaVentas, int numFactura)
        {
            var query = listaVentas.Where(factura => factura.NUMFACTURA == numFactura).ToList();

            foreach(var fact in query)
            {
                if(fact.DESHABILITAR) return true;
            }

            return false;
        } 
    }
}