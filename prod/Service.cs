using System.Collections.Generic;
using prod.p;
using System;
using System.Text.RegularExpressions;

namespace prod.s
{
    class Service
    {
        public static List<Producto> listaProductos;
        private String producto, codigo;
        private double precio;
        private int cantidad;

        public void insertProducto()
        {
            String confirmar = "si";

            Boolean continuar = true;

            Console.WriteLine("\nHas selecionado el 1 (Crear producto) por favor ingresa los siguientes datos");

            while(continuar)
            {    
                if(confirmar.Equals("si"))
                {
                    leerDatos();

                    if(Producto.validarCodigo(codigo, listaProductos)) Console.WriteLine($"\nEl producto con el codigo '{codigo}' ya esta registrado, producto no registrado");
                    
                    else if(Producto.validaciones(listaProductos, producto, codigo, precio, cantidad))
                    {
                        listaProductos.Add(new Producto(producto, precio, cantidad, codigo));

                        Console.WriteLine("\nproducto registrado correctamente");
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                
                Console.WriteLine("\n¿Quiere registrar un producto? ");

                confirmar = Console.ReadLine();
            }
        }

        public void selectProducto()
        {
            String confirmar = "si";

            Boolean continuar = true;

            String codBusqueda;

            Console.WriteLine("\nHas selecionado el 2 (Buscar producto)");

            while(continuar)
            {
                if(confirmar.Equals("si"))
                {
                    Console.Write("Codigo del producto que quiere buscar: ");

                    codBusqueda = Console.ReadLine();

                    if(Producto.validarCodigo(codBusqueda, listaProductos) != true) Console.WriteLine("El producto con el codigo '{0}' no existe o no esta registrado", codBusqueda);

                    else 
                    {
                        Producto.getProductoBusqueda(codBusqueda, listaProductos);
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                    
                Console.WriteLine("\n¿Quiere buscar un producto? ");

                confirmar = Console.ReadLine();
            }
        }

        public void updateProducto()
        {
            String confirmar = "si";

            Boolean continuar = true;

            String codBusqueda;

            Console.WriteLine("\nHas selecionado el 3 (Modificar producto)");

            while(continuar)
            {
                if(confirmar.Equals("si"))
                {
                    Console.Write("codigo del producto que quiere modificar: ");

                    codBusqueda = Console.ReadLine();

                    if(Producto.validarCodigo(codBusqueda, listaProductos) != true) Console.WriteLine("El producto con el codigo '{0}' no existe o no esta registrado", codBusqueda);

                    else 
                    {
                        Console.WriteLine("\nPor favor ingrese la nueva informacion del producto");

                        leerDatos();

                        if(Producto.validaciones(listaProductos, producto, codigo, precio, cantidad))
                        {
                            Producto.setProductoBusqueda(listaProductos, producto, precio, cantidad, codigo);
                        }
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                    
                Console.WriteLine("\n¿Quiere modificar un producto? ");

                confirmar = Console.ReadLine();
            }
        }

        public void deleteProducto()
        {
            String confirmar = "si";

            Boolean continuar = true;

            String codBusqueda;

            Console.WriteLine("\nHas selecionado el 4 (Eliminar producto)");

            while(continuar)
            {
                if(confirmar.Equals("si"))
                {
                    Console.Write("Codigo del producto que quiere eliminar: ");

                    codBusqueda = Console.ReadLine();

                    if(Producto.validarCodigo(codBusqueda, listaProductos) != true) Console.WriteLine("El cliente con el documento '{0}' no existe o no esta registrado", codBusqueda);

                    else 
                    {
                        if(Producto.removeProducto(codBusqueda, listaProductos)== false) break;
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                    
                Console.WriteLine("\n¿Quiere eliminar un producto? ");

                confirmar = Console.ReadLine();
            }
        }

        void leerDatos()
        {
            Console.Write("\nCodigo: ");

            codigo = Console.ReadLine();
            
            Console.Write("Producto: ");

            producto = Console.ReadLine();

            Console.Write("Precio: ");

            catchExPrecio();

            Console.Write("Cantidad: ");

            catchExCantidad();
        }

        void catchExPrecio()
        {
            try
            {
                precio = double.Parse(Console.ReadLine());
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Error de formato, solo se permiten numeros");
            }
            catch(System.OverflowException)
            {
                Console.WriteLine("Numero demasiado largo, por favor ingrese un numero menor a: " + double.MaxValue);
            }
        }

        void catchExCantidad()
        {
            try
            {
                cantidad = int.Parse(Console.ReadLine());
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Error de formato, solo se permiten numeros");
            }
            catch(System.OverflowException)
            {
                Console.WriteLine("Numero demasiado largo, por favor ingrese un numero menor a: " + int.MaxValue);
            }
        }
    }
}