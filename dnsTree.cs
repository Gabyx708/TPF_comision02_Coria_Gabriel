using System;
using System.Collections.Generic;
using System.Text;
using dataEstruct;

namespace TPF_dns
{
    class dnsTree
    {
        /*creacion del arbol DNS*/
        private registroDNS r,c,n,o;
        private ArbolGeneral<registroDNS> root;
 

        public dnsTree() /*al instanciar el objeto se creara un sistema DNS "predefinido"*/
        {   
            /*se crean los primeros registros*/
            r = new registroDNS("ROOT", "0.0.0.0", "dns");
            c = new registroDNS("com", "170.0.0.0", "dns");
            n = new registroDNS("net", "180.0.0.0", "dns");
            o = new registroDNS("org", "190.0.0.0", "dns");

            /*se crean los arboles hijos de la raiz*/
            root = new ArbolGeneral<registroDNS>(r);
            root.agregarHijo(new ArbolGeneral<registroDNS>(c));
            root.agregarHijo(new ArbolGeneral<registroDNS>(n));
            root.agregarHijo(new ArbolGeneral<registroDNS>(o));

        }
        
        public ArbolGeneral<registroDNS> dnsSistema()
        {
            return root;
        }
        public void addRegister(registroDNS dns)
        {
           string[] dominios = dns.getTag().Split('.');
           string nomDomi = dominios[0];
           string subdominio = dominios[1];
           string superior = dominios[2];

            /*nuevo hijo para agregar al arbol*/
            ArbolGeneral<registroDNS> newReg = new ArbolGeneral<registroDNS>(dns);
            add(newReg,root);

             void add(ArbolGeneral<registroDNS> n,ArbolGeneral<registroDNS> r)
            {
                foreach (var x in r .getHijos())
                {
                    if (x.getDatoRaiz().getTag() == superior)
                    {
                        x.agregarHijo(newReg);                  
                    }
                    else
                    {
                        add(n,x);
                    }
                }
            }

          
           
        }

        ///
    }
  
}
