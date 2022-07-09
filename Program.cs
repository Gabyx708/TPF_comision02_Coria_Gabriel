using System;

namespace TPF_dns
{
    class Program
    {
        static void Main(string[] args)
        {
            registroDNS test = new registroDNS("www.argentina.org","150.0.150.2","WWW");
            registroDNS test2 = new registroDNS("www.gobierno.org", "170.0.150.2", "WWW");
            registroDNS test3 = new registroDNS("es.google.com", "8.8.8.8", "WWW");
            registroDNS test4 = new registroDNS("es.campus.net", "10.50.50.8", "WWW");
            registroDNS test5 = new registroDNS("en.google.com", "10.50.50.8", "WWW");
            registroDNS test6 = new registroDNS("es.argentina.org", "10.50.50.8", "WWW");
            registroDNS test7 = new registroDNS("www.argentina.com", "10.0.0.8", "www");

            dnsTree x = dnsTree.getInstance();

            x.addRegister(test);
            x.addRegister(test2);
            x.addRegister(test3);
            x.addRegister(test4);
            x.addRegister(test5);
            x.addRegister(test6);
            x.addRegister(test7);

            adminModule admin = adminModule.getInstance();
            queryModule q = queryModule.getInstance();

            Console.Write("\n******************");
            Console.Write("\n*   BIENVENID@   *\n");
            Console.Write("******************");
            while (true)
            {
            Console.Write("\n ¿que haremos hoy?");
            Console.Write("\n 1- ADMINISTRAR");
            Console.Write("\n 2- CONSULTAR \n");
            string opcion = Console.ReadLine();

            
                switch (opcion)
                {
                    case "1": admin.inicio(); break;
                    case "2": q.inicio(); break;
                    default: x.dnsSistema().porNiveles(); break;
                } 
            }
    
        }
    }
}
