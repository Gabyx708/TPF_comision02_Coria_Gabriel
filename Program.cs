using System;

namespace TPF_dns
{
    class Program
    {
        static void Main(string[] args)
        {
            registroDNS test = new registroDNS("www.argentina.org","150.0.150.2","WWW");
            registroDNS test2 = new registroDNS("www.gobierno.org", "170.0.150.2", "WWW");
            registroDNS test3 = new registroDNS("www.google.com", "8.8.8.8", "WWW");

            dnsTree x = new dnsTree();

            x.addRegister(test);
            x.addRegister(test2);
            x.addRegister(test3);
            x.dnsSistema().postOrden();
        }
    }
}
