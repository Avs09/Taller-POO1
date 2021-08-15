using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace client.c
{
    class Cliente
    {
        public Cliente(String cliente, String direccion, String telefono, String documento)
        {
            CLIENTE = cliente;

            DIRECCION = direccion;

            TELEFONO = telefono;

            DOCUMENTO = documento;
        }

        public String CLIENTE {get; set;}

        public String DIRECCION {get; set;}

        public String TELEFONO {get; set;}

        public String DOCUMENTO {get; set;}

        public static Boolean removeCliente(String documento, List<Cliente> listaClientes)
        {
            Console.WriteLine($"¿Esta seguro de eliminar el cliente '{documento}'? ");

            String confirmar = Console.ReadLine();

            if(confirmar.Equals("si"))
            {
                var query = listaClientes.First(cliente => cliente.DOCUMENTO.Equals(documento));

                listaClientes.Remove(query);

                Console.WriteLine($"\nEl cliente '{query.CLIENTE}' fue eliminado correctamente");
            }
            else if(confirmar.Equals("no")) return false;

            else if(Regex.IsMatch(confirmar, @"^[0-9]+$")) Console.WriteLine("Formato no valido, no se permiten numeros");

            else Console.WriteLine("\nRespuesta incorrecta, debes responder si o no");

            return true;
        }

        public static void getClienteBusqueda(String documento, List<Cliente> listaClientes)
        {
            var query = listaClientes.Where(cliente => cliente.DOCUMENTO.Equals(documento)).ToList();

            Console.WriteLine("\n*** INFORMACIÓN DEL CLIENTE ***");

            foreach(var cliente in query)
            {
                Console.WriteLine("Nombre: " + cliente.CLIENTE);

                Console.WriteLine("Documento: " + cliente.DOCUMENTO);

                Console.WriteLine("Direccion: " + cliente.DIRECCION);

                Console.WriteLine("Telefono: " + cliente.TELEFONO);
            }
        }

        public static void setClienteBusqueda(List<Cliente> listaClientes, String documento, String nombre, String direccion, String telefono)
        {
            var query = listaClientes.Where(cliente => cliente.DOCUMENTO.Equals(documento)).ToList();

            foreach(var cliente in query)
            {
                cliente.CLIENTE = nombre;

                cliente.DIRECCION = direccion;

                cliente.TELEFONO = telefono;
            }

            Console.WriteLine("\nEl cliente con el documento '{0}' ha sido modificado correctamente", documento);
        }

        public static Boolean validaciones(List<Cliente> listaClientes, String nombre, String documento, String direccion, String telefono)
        {
            if(String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(documento) || String.IsNullOrEmpty(direccion) || String.IsNullOrEmpty(telefono))  Console.WriteLine("\nNingun campo puede estar vacio o nulo, cliente no registrado");
            
            else if(Regex.IsMatch(nombre, @"^[0-9]+$")) Console.WriteLine("El nombre solo puede contener caracteres");

            else if(Regex.IsMatch(documento, @"^[0-9]+$") == false || Regex.IsMatch(telefono, @"^[0-9]+$") == false) Console.WriteLine("El documento y el telefono solo deben ser numeros");
            
            else 
            {
                return true;
            }

            return false;
        }
        
        public static Boolean validarDocumento(String documento, List<Cliente> listaClientes) => listaClientes.Any(cliente => cliente.DOCUMENTO.Equals(documento)) ? true : false;
    }
}