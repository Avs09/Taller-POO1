using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace prod.p
{
    class Producto
    {
        public Producto(string producto, double precio, int cantidad, string codigo)
        {
            PRODUCTO = producto;

            PRECIO = precio;

            CANTIDAD = cantidad;

            CODIGO = codigo;
        }

        public string PRODUCTO {get; set;}

        public double PRECIO {get; set;}

        public int? CANTIDAD {get; set;}

        public string CODIGO {get; set;}

        public static Boolean removeProducto(String codigo, List<Producto> listaProductos)
        {
            Console.WriteLine($"¿Esta seguro de eliminar el producto '{codigo}'? ");

            String confirmar = Console.ReadLine();

            if(confirmar.Equals("si"))
            {
                var query = listaProductos.First(producto => producto.CODIGO.Equals(codigo));

                listaProductos.Remove(query);

                Console.WriteLine($"\nEl producto '{query.PRODUCTO}' fue eliminado correctamente");
            }
            else if(confirmar.Equals("no")) return false;

            else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

            else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");

            return true;
        }
        public static Boolean validaciones(List<Producto> listaProductos, String producto, String codigo, double? precio = null, int? cantidad = null)
        {
            if(String.IsNullOrEmpty(producto) || String.IsNullOrEmpty(codigo) || precio == null || cantidad == null)  Console.WriteLine("\nNingun campo puede estar vacio o nulo, producto no registrado");
            
            else if(Regex.IsMatch(codigo, @"^[0-9]+$") == false) Console.WriteLine("\nEl codigo solo debe contener numeros");

            else if(Regex.IsMatch(producto, @"^[0-9]+$")) Console.WriteLine("\nEl producto solo puede contener caracteres");

            else if(compararProducto(listaProductos, producto)== false) Console.WriteLine("\nYa existe un producto con el nombre de '{0}' ", producto);

            else if(precio <= 0 || cantidad <= 0) Console.WriteLine("\nEl precio y/o la cantidad no deben ser menores o igual a cero");
            
            else return true;
    
            return false;
        }

        public static void getProductoBusqueda(String codigo, List<Producto> listaProductos)
        {
            var query = listaProductos.Where(producto => producto.CODIGO.Equals(codigo)).ToList();

            Console.WriteLine("\n*** INFORMACIÓN DEL PRODUCTO ***");

            foreach(var producto in query)
            {
                Console.WriteLine("Producto: " + producto.PRODUCTO);

                Console.WriteLine("Codigo: " + producto.CODIGO);

                Console.WriteLine("Precio: " + producto.PRECIO);

                Console.WriteLine("Cantidad: " + producto.CANTIDAD);
            }
        }

        public static void setProductoBusqueda(List<Producto> listaProductos, String producto, double precio, int cantidad, String codigo)
        {
            var query = listaProductos.Where(producto => producto.CODIGO.Equals(codigo)).ToList();

            foreach(var prod in query)
            {
                prod.PRODUCTO = producto;

                prod.CODIGO = codigo;

                prod.PRECIO = precio;

                prod.CANTIDAD = cantidad;
            }

            Console.WriteLine("\nEl producto con el codigo '{0}' ha sido modificado correctamente", codigo);
        }
        public static Boolean validarCodigo(String codigo, List<Producto> listaProductos) => listaProductos.Any(producto => producto.CODIGO.Equals(codigo)) ? true : false;

        public static Boolean compararProducto(List<Producto> listaProductos, String producto)
        {
            String productoA = "";

            foreach(var prod in listaProductos)
            {
                productoA = prod.PRODUCTO;

                if(listaProductos.Exists(p=> producto.Equals(productoA)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}