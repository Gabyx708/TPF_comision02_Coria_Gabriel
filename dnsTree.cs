using System;
using System.Collections.Generic;
using System.Text;
using dataEstruct;

namespace TPF_dns
{
    class dnsTree
    {
        /*creacion del arbol DNS*/
        private static dnsTree dnsSys = null;
        private registroDNS r,c,n,o,g;
        private ArbolGeneral<registroDNS> root;
        
        public static dnsTree getInstance()
        {
            if (dnsSys == null)
                dnsSys = new dnsTree();
            return dnsSys;
        }

        private dnsTree() /*al instanciar el objeto se creara un sistema DNS "predefinido"*/
        {   
            /*se crean los primeros registros*/
            r = new registroDNS("ROOT", "0.0.0.0", "dns");
            c = new registroDNS("com", "120.0.0.0", "dns");
            n = new registroDNS("net", "130.0.0.0", "dns");
            o = new registroDNS("org", "140.0.0.0", "dns");
            g = new registroDNS("google","8.8.8.8","dns");
            /*se crean los arboles hijos de la raiz*/
            root = new ArbolGeneral<registroDNS>(r);
            root.agregarHijo(new ArbolGeneral<registroDNS>(c));
            root.agregarHijo(new ArbolGeneral<registroDNS>(n));
            root.agregarHijo(new ArbolGeneral<registroDNS>(o));
            root.agregarHijo(new ArbolGeneral<registroDNS>(g));

        }
        
        public ArbolGeneral<registroDNS> dnsSistema()
        {
            return root; /*contiene todo el sistema dns*/
        }
        public void addRegister(registroDNS dns)
        {
           string[] dominios = dns.getTag().Split('.');

            /*nuevo hijo para agregar al arbol*/
            ArbolGeneral<registroDNS> newReg = new ArbolGeneral<registroDNS>(dns);
            _add(newReg,root,dominios);

                
        }

        private void _add(ArbolGeneral<registroDNS> n, ArbolGeneral<registroDNS> r, string[] tag)
        {
            foreach (var hijos in r.getHijos())
            {
                if(hijos.getDatoRaiz().getTag() == tag[2])
                {
                    Console.WriteLine("por su tag 2 agregue a: "+n.getDatoRaiz());
                    hijos.agregarHijo(n);
                    break;
                }else if (hijos.getDatoRaiz().getTag() == tag[1])
                {
                    Console.WriteLine("por su tag 1 agregue a: " + n.getDatoRaiz());
                    hijos.agregarHijo(n);
                    break;
                }else if (hijos.getDatoRaiz().getTag() == tag[1] && tag[0] != hijos.getDatoRaiz().getTag())
                {
                    Console.WriteLine("por su nose agregue a: " + n.getDatoRaiz());
                    hijos.agregarHijo(n);
                    break;
                }
                else
                {
                    _add(n,hijos,tag);
                }
            }

        }
        ///
    }
  
}
