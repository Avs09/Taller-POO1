using System;
using System.Text.RegularExpressions;
using System.Linq;
using client.c;
using System.Collections.Generic;
using venta.f;

namespace venta.v
{
    class Venta : Factura{

        public Venta(String documento, String fecha, String codigo, int cantidad, int numFactura, double valorTotal, String producto, double valorP, Boolean deshabilitar)
        {
            DOCUMENTO = documento;

            PRODUCTO = producto;

            FECHA = fecha;

            CODIGO = codigo;

            CANTIDAD = cantidad;

            NUMFACTURA = numFactura;

            VALORTOTAL = valorTotal;

            VALORP = valorP;

            DESHABILITAR = deshabilitar;
        }

        public String DOCUMENTO {get; set;}
        public String PRODUCTO {get; set;}
        public String FECHA {get; set;}
        public String CODIGO {get; set;}
        public int CANTIDAD {get; set;}
        public int NUMFACTURA {get; set;}
        public double VALORTOTAL {get; set;}
        public double VALORP {get; set;}
        public Boolean DESHABILITAR {get; set;}
        
        public static Boolean validaciones(String documento, int? cantidad, String producto)
        {
            getCantProd(producto, cantidad);

            if(String.IsNullOrEmpty(documento) || cantidad == null || String.IsNullOrEmpty(producto))  Console.WriteLine("\nNingun campo puede estar vacio o nulo, venta no realizada");

            else if(Regex.IsMatch(documento, @"^[0-9]+$") == false) Console.WriteLine("\nEl documento debe contener solo numeres");

            else if(Cliente.validarDocumento(documento, client.s.Service.listaClientes) == false) Console.WriteLine($"\nEl cliente con el documento '{documento}' no existe o no esta registrado");
            
            else if(Regex.IsMatch(producto, @"^[0-9]+$")) Console.WriteLine("\nEl producto solo puede contener caracteres");

            else if(validarProducto(producto) != true) Console.WriteLine("\nEl producto '{0}' no existe o no esta en el inventario", producto);

            else if(validarCantProducto(cantidad, producto) == false) Console.WriteLine($"\nActualmente no tenemos disponibles esa cantidad de productos. cant disponibles: {getCantProd(producto, cantidad)}");

            else if(cantidad <= 0) Console.WriteLine("\nLa cantidad debe ser mayor a cero");
            
            else return true;
    
            return false;
        }

        static Boolean validarProducto(String producto) => prod.s.Service.listaProductos.Any(prod => prod.PRODUCTO.Equals(producto)) ? true : false;

        static Boolean validarCantProducto(int? cantidad, String producto)
        {
            if(cantidad > getCantProd(producto, cantidad)) return false;
            
            return true;
        }

        static List<prod.p.Producto> getProductoSelect(String producto)
        {
            String codigo = "";

            var query = prod.s.Service.listaProductos.Where(p=> p.PRODUCTO.Equals(producto)).ToList();

            foreach(var prod in query)
            {
                codigo = prod.CODIGO;
            }

            var query2 = prod.s.Service.listaProductos.Where(p=> p.CODIGO.Equals(codigo)).ToList();

            return query2;
        }

        public static int? descontarCantProd(String producto, int? cantidad)
        {
            Boolean c = true;

            int? cant = 0;

            foreach(var prod in getProductoSelect(producto))
            {
                if(c) 
                {
                    prod.CANTIDAD -= cantidad;

                    c = false;
                }

                cant = prod.CANTIDAD;
            }

            return cant;
        }

        static int? getCantProd(String producto, int? cantidad)
        {
            int? cant = 0;

            foreach(var prod in getProductoSelect(producto))
            {
                cant = prod.CANTIDAD;
            }

            return cant;
        }

        public static double getValorTotal(String producto, int cantidad)
        {
            double valorT = 0;

            foreach(var prod in getProductoSelect(producto))
            {
                valorT = prod.PRECIO * cantidad;
            }

            return valorT;
        }

        public static double getValorP(String producto)
        {
            double valor = 0;

            foreach(var prod in getProductoSelect(producto))
            {
                valor = prod.PRECIO;
            }

            return valor;
        }

        public static Boolean validarNumFact(int fact, List<Venta> listaVentas) => listaVentas.Any(fac=> fac.NUMFACTURA == fact) ? true : false;
        
        public static void getFacturaBusqueda(List<Venta> listaVentas, int numFactura)
        {
            var query = listaVentas.Where(venta => venta.NUMFACTURA == numFactura).ToList();

            Console.WriteLine("\n*** INFORMACIÓN DE LA FACTURA ***");

            foreach(var factura in query)
            {
                Factura.encabezado(factura.DOCUMENTO, factura.VALORTOTAL, factura.NUMFACTURA, factura.CODIGO);

                Factura.detalle(factura.PRODUCTO, factura.CANTIDAD, factura.VALORP, factura.FECHA);
            }
        }

        public static String getCodigo(String producto)
        {
            String codigo = "";

            foreach(var prod in getProductoSelect(producto))
            {
                codigo = prod.CODIGO;
            }

            return codigo;
        }
    }
}