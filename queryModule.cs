using System;
using System.Collections.Generic;
using System.Text;

namespace TPF_dns
{
    class queryModule
    {
        private dnsTree dns;
        private static queryModule query = null;
        private queryModule()
        {
            dns = dnsTree.getInstance();
        }

        public static queryModule getInstance()
        {
            if (query == null)
                query = new queryModule();
            return query;
        }
        public void inicio()
        {
            Console.WriteLine("¿que desea hacer hoy?:\n1- consultar por un dominio\n2-buscar subdominios");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": consultarDominio(); break;
                case "2": consultarDominio(); break;
                default: inicio(); break;
            }
        }

        private void consultarDominio()
        {
            Console.Write("ingrese el dominio que desea consultar: ");
            string dominio = Console.ReadLine();
            registroDNS resultado = dns.buscarDominio(dominio);

            if(resultado != null)
            {
                Console.WriteLine("\nEh encontrado este registro: \n"+resultado.Presentar());
            }
            else
            {
                Console.WriteLine("Ups! no hemos encontrado nada :( \n");
            }          
        }

        
    }
}
