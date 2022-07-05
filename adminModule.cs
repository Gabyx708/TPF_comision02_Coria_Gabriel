using System;
using System.Collections.Generic;
using System.Text;

namespace TPF_dns
{
    class adminModule
    {
        private dnsTree dns;

        public adminModule()
        {
            dns = dnsTree.getInstance();
        }

        public void inicio()
        {
            Console.WriteLine("¿que desea hacer hoy?:\n1- agregar un dominio\n2-eliminar un dominio");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": ingresarDominio(); break;
                case "2": eliminarDominio(); break;
                default: inicio(); break;
            }
        }
        private void ingresarDominio()
        {
            Console.WriteLine("/-------INGRESAR DOMINIO-----/");
            Console.Write("ingrese el nombre del dominio: ");
            string dominio = Console.ReadLine();

            Console.Write("ingrese la direccion IP del equipo: ");
            string dicIP = Console.ReadLine();

            Console.Write("ingrese el tipo de servicio: ");
            string service = Console.ReadLine();

            Console.WriteLine(" ");

            registroDNS nuevoR = new registroDNS(dominio,dicIP,service);
            dns.addRegister(nuevoR);
        }

        private void eliminarDominio()
        {
            Console.Write("ingresa el dominio que quieres eliminar: ");
            string url = Console.ReadLine();
            dns.eliminDom(url);
            
        }
    }
}
