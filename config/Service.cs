using System;
using client.c;
using prod.p;
using config.m;

namespace config.s
{
    class Service
    {
        public void insertDiezClientes()
        {
            client.s.Service.listaClientes.Add(new Cliente("Sofia", "Cr67A#87B15", "3202451500", "1010470747"));

            client.s.Service.listaClientes.Add(new Cliente("Alex", "Cl27A#8-15", "3009091001", "1000900545"));
            client.s.Service.listaClientes.Add(new Cliente("Mariana", "Cr70#27-05", "3104515005", "1000422927"));

            client.s.Service.listaClientes.Add(new Cliente("Isabela", "Cl37C#75B", "3014548150", "1002909236"));
            client.s.Service.listaClientes.Add(new Cliente("Yimmi", "Cr76#87-15", "3008421500", "1000270747"));

            client.s.Service.listaClientes.Add(new Cliente("Valeria", "Cr67A#87B15", "3202451500", "1020889334"));

            client.s.Service.listaClientes.Add(new Cliente("Valentina", "Cl80-47C", "3152456775", "1000785242"));

            client.s.Service.listaClientes.Add(new Cliente("Samuel", "Cr54#22-15", "320714845", "1002886642"));

            client.s.Service.listaClientes.Add(new Cliente("Camila", "Cl640C-70A", "3002454040", "1000739663"));

            client.s.Service.listaClientes.Add(new Cliente("Kevin", "Crl24-70C", "3106895050", "1002928747"));
        }

        public void insertDiezProductos()
        {
            prod.s.Service.listaProductos.Add(new Producto("Camisa nike negra", 135.000, 12, "289028928392"));

            prod.s.Service.listaProductos.Add(new Producto("tennis nike negros", 385.000, 5, "384028325322"));

            prod.s.Service.listaProductos.Add(new Producto("pantalones rifle clasico", 255.000, 40, "402902923322"));

            prod.s.Service.listaProductos.Add(new Producto("Buso americanino gris", 289.999, 2, "20928945376"));

            prod.s.Service.listaProductos.Add(new Producto("Pantaloneta nike blanca", 115.000, 12, "920386820327"));

            prod.s.Service.listaProductos.Add(new Producto("Camisa arturo calle tipo polo", 315.000, 8, "482039238422"));

            prod.s.Service.listaProductos.Add(new Producto("Camisa koaj blanca", 135.000, 12, "563925573829"));

            prod.s.Service.listaProductos.Add(new Producto("Tennis addidas negros", 400.000, 10, "141329318392"));

            prod.s.Service.listaProductos.Add(new Producto("Tennis superdry talla 9", 379.999, 1, "221281418392"));

            prod.s.Service.listaProductos.Add(new Producto("Gorra monastery negra", 189.999, 15, "299392933392"));
        }

        public void setNombreEmpresa(String nombre)
        {
            Menu.empresas = new c.ConfigurarEmpresa(nombre);
        }
    }
}