using System;
using venta.f;

namespace report.s
{
    class Service : Factura
    {
        public void listarClientes()
        {
            int numClientes = 0;

            Console.WriteLine("\nHas selecionado el 1 (Listar clientes)");

            if(client.s.Service.listaClientes.Count >=1)
            {
                Console.WriteLine("\n*** INFORMACION CLIENTES ***");

                foreach(var clientes in client.s.Service.listaClientes)
                {
                    numClientes++;

                    Console.WriteLine($"\nCliente #{numClientes}, sus datos son");

                    Console.WriteLine("Nombre: " + clientes.CLIENTE);

                    Console.WriteLine("Documento: " + clientes.DOCUMENTO);

                    Console.WriteLine("Direccion: " + clientes.DIRECCION);

                    Console.WriteLine("Telefono: " + clientes.TELEFONO);
                }

                Console.WriteLine("\nTotal clientes: " + numClientes);
            }
            else Console.WriteLine("\nNo existe ningun cliente para listar");
        }

        public void listarProductos()
        {
            int numProductos = 0;

            Console.WriteLine("\nHas selecionado el 2 (Listar productos)");

            if(prod.s.Service.listaProductos.Count >= 1)
            {
                Console.WriteLine("\n*** INFORMACION PRODUCTOS ***");
            
                foreach(var productos in prod.s.Service.listaProductos)
                {
                    numProductos++;

                    Console.WriteLine($"\nProducto #{numProductos}, sus datos son");

                    Console.WriteLine("Producto: " + productos.PRODUCTO);

                    Console.WriteLine("Codigo: " + productos.CODIGO);

                    Console.WriteLine("Precio: " + productos.PRECIO);

                    Console.WriteLine("Cantidad: " + productos.CANTIDAD);
                }

                Console.WriteLine("\nTotal productos: " + numProductos);
            }
            else Console.WriteLine("\nNo existe ningun producto para listar");
        }

        public void listarFacturas()
        {
            int numFacturas = 0;

            Console.WriteLine("\nHas selecionado el 3 (Listar facturas)");

            if(venta.s.Service.listaVentas.Count >= 1)
            {
                Console.WriteLine("\n*** INFORMACION FACTURAS (ENCABEZADO)***");
            
                foreach(var facturas in venta.s.Service.listaVentas)
                {
                    numFacturas++;

                    Factura.encabezado(facturas.DOCUMENTO, facturas.VALORTOTAL, facturas.NUMFACTURA, facturas.CODIGO);

                    Console.WriteLine();
                }

                Console.WriteLine("\nTotal facturas: " + numFacturas);
            }
            else Console.WriteLine("\nNo existe ninguna factura para listar");
        }
    }
}