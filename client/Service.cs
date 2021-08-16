using System;
using client.c;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace client.s
{
    class Service
    {
        private String nombre, direccion, telefono, documento;
        public static List<Cliente> listaClientes;
        
        public void insertCliente()
        {
            String confirmar = "si";

            Boolean continuar = true;

            Console.WriteLine("\nHas selecionado el 1 (Crear cliente) por favor ingresa los siguientes datos");

            while(continuar)
            {    
                if(confirmar.Equals("si"))
                {
                    leerDatos();

                    if(Cliente.validarDocumento(documento, listaClientes)) Console.WriteLine($"\nEl cliente con el documento '{documento}' ya esta registrado, cliente no registrado");
                    
                    else if(Cliente.validaciones(listaClientes, nombre, documento, direccion, telefono))
                    {
                        listaClientes.Add(new Cliente(nombre, direccion, telefono, documento));

                        Console.WriteLine("\nCliente registrado correctamente");
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                
                Console.WriteLine("\n¿Quiere registrar un cliente? ");

                confirmar = Console.ReadLine();
            }
        }

        public void selectCliente()
        {
            String confirmar = "si";

            Boolean continuar = true;

            String docBusqueda;

            Console.WriteLine("\nHas selecionado el 2 (Buscar cliente)");

            while(continuar)
            {
                if(confirmar.Equals("si"))
                {
                    Console.Write("Documento del cliente que quiere buscar: ");

                    docBusqueda = Console.ReadLine();

                    if(Cliente.validarDocumento(docBusqueda, listaClientes) != true) Console.WriteLine("El cliente con el documento '{0}' no existe o no esta registrado", docBusqueda);

                    else 
                    {
                        Cliente.getClienteBusqueda(docBusqueda, listaClientes);
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                    
                Console.WriteLine("\n¿Quiere buscar un cliente? ");

                confirmar = Console.ReadLine();
            }
        }

        public void updateCliente()
        {
            String confirmar = "si";

            Boolean continuar = true;

            String docBusqueda;

            Console.WriteLine("\nHas selecionado el 3 (Modificar cliente)");

            while(continuar)
            {
                if(confirmar.Equals("si"))
                {
                    Console.Write("Documento del cliente que quiere modificar: ");

                    docBusqueda = Console.ReadLine();

                    if(Cliente.validarDocumento(docBusqueda, listaClientes) != true) Console.WriteLine("El cliente con el documento '{0}' no existe o no esta registrado", docBusqueda);

                    else 
                    {
                        Console.WriteLine("\nPor favor ingrese la nueva informacion del cliente");

                        leerDatos();

                        if(Cliente.validaciones(listaClientes, nombre, documento, direccion, telefono))
                        {
                            Cliente.setClienteBusqueda(listaClientes, documento, nombre, direccion, telefono);
                        }
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                    
                Console.WriteLine("\n¿Quiere modificar un cliente? ");

                confirmar = Console.ReadLine();
            }
        }

        public void deleteCliente()
        {
            String confirmar = "si";

            Boolean continuar = true;

            String docBusqueda;

            Console.WriteLine("\nHas selecionado el 4 (Eliminar cliente)");

            while(continuar)
            {
                if(confirmar.Equals("si"))
                {
                    Console.Write("Documento del cliente que quiere eliminar: ");

                    docBusqueda = Console.ReadLine();

                    if(Cliente.validarDocumento(docBusqueda, listaClientes) != true) Console.WriteLine("El cliente con el documento '{0}' no existe o no esta registrado", docBusqueda);

                    else 
                    {
                        if(Cliente.removeCliente(docBusqueda, listaClientes)== false) break;
                    }
                }
                else if(confirmar.Equals("no")) break;

                else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

                else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");
                    
                Console.WriteLine("\n¿Quiere eliminar un cliente? ");

                confirmar = Console.ReadLine();
            }
        }

        void leerDatos()
        {
            Console.Write("\nDocumento: ");

            documento = Console.ReadLine();
            
            Console.Write("Nombre: ");

            nombre = Console.ReadLine();

            Console.Write("Telefono: ");

            telefono = Console.ReadLine();

            Console.Write("Direccion: ");

            direccion = Console.ReadLine();
        }
    }
}