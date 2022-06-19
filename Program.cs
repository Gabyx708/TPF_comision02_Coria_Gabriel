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

            dnsTree x = dnsTree.getInstance();

            /*adminModule admin = new adminModule();
            admin.inicio();*/

            x.addRegister(test);
            x.addRegister(test2);
            x.addRegister(test6);
            x.addRegister(test4);
          

            x.dnsSistema().porNiveles();
        }
    }
}
