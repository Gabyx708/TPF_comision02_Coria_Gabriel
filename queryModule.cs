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
            Console.WriteLine("\n¿que desea hacer hoy?:\n1-consultar por un dominio\n2-buscar subdominios\n3-buscar en profundidad");
            Console.Write(" opcion: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": consultarDominio(); break;
                case "2": consultarSubdominio(); break;
                case "3": busquedaProfundidad(); break;
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

        private void consultarSubdominio()
        {
            Console.Write("Subdominio a consultar: ");
            string sub = Console.ReadLine();

            var arb = dns.busquedaSubdominio(sub);

            if (arb != null )
            {
              arb.porNiveles();
            }
            else
            {
                Console.WriteLine("hmmm...no encotramos lo que estas buscando :(");
            }      
        }

        private void busquedaProfundidad()
        {
            Console.Write("Profundidad a consultar: ");
            int p = int.Parse(Console.ReadLine());

            if (p == 0)
            {
                p = 1;
            }
             dns.profundidad(p);
       
        }
    }
}
