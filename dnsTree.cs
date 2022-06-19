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
            Console.WriteLine("AQUI ESTOY!!!! 4");
            //primero la raiz
            if (tag[2] == r.getDatoRaiz().getTag())
            {
                if (!siExiste(r, tag[1])) //si los hijos no poseen de nombre el tag 1
                {
                    Console.WriteLine("AQUI ESTOY!!!! 2");
                    registroDNS dnsAux = new registroDNS(tag[1], "", "");
                    ArbolGeneral<registroDNS> aux = new ArbolGeneral<registroDNS>(dnsAux);
                    r.agregarHijo(aux);
                    _add(n, aux, tag);
                }

            }
            else if (tag[1] == r.getDatoRaiz().getTag())
            {
                r.agregarHijo(n);
            }
            else
            {
                foreach(var hijo in r.getHijos())
                {
                    _add(n,hijo,tag);
                }
            }

        }
        ///

        private bool siExiste(ArbolGeneral<registroDNS> chek, string tag) //chequea que ningun hijo tenga ese tag
        {
            int count = 0;
            for (int i = 0; i < chek.getHijos().Count;i++)
            {
                if((chek.getHijos()[i]).getDatoRaiz().getTag() != tag)
                {
                    count++;
                }
            }

            if(count == chek.getHijos().Count)
            {
                return false;
            }

            return true;
        }
    }
  
}
