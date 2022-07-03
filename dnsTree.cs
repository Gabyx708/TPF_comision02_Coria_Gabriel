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
        private registroDNS r, c, n, o;
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

            /*se crean los arboles hijos de la raiz*/
            root = new ArbolGeneral<registroDNS>(r);
            root.agregarHijo(new ArbolGeneral<registroDNS>(c));
            root.agregarHijo(new ArbolGeneral<registroDNS>(n));
            root.agregarHijo(new ArbolGeneral<registroDNS>(o));
 

        }
        
        /*----LOGICA DE AGREGADO----*/
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
            
            //primero la raiz
            if (tag[tag.Length -1] == r.getDatoRaiz().getTag())
            {
                if (!siExiste(r, tag[1])) //si los hijos no poseen de nombre el tag 1
                {
                   
                    registroDNS dnsAux = new registroDNS(tag[1], "", "");
                    ArbolGeneral<registroDNS> aux = new ArbolGeneral<registroDNS>(dnsAux);
                    r.agregarHijo(aux);
                    _add(n, aux, tag);
                }
                else
                {
                   ArbolGeneral<registroDNS> hijo = EsteHijo(r,tag[1]);
                    hijo.agregarHijo(n);
                }
            

            }
            else if (tag[tag.Length - 2] == r.getDatoRaiz().getTag())
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

        private ArbolGeneral<registroDNS> EsteHijo(ArbolGeneral<registroDNS> r,string tag)
        {
            foreach(var child in r.getHijos())
            {
                if (child.getDatoRaiz().getTag() == tag)
                    return child;
            }

            return null;
        }


        /*-----LOGICA DE BUSQUEDA----*/

        public registroDNS buscarDominio(string dominio)
        {

            registroDNS encontrado = _buscarDominio(dnsSistema(),dominio,null);
            return encontrado;
        }

        private registroDNS _buscarDominio(ArbolGeneral<registroDNS> r,string d,registroDNS found)
        {
            if (r.getDatoRaiz().getTag() == d)
            {
                found = r.getDatoRaiz();
                return found;
            }

            foreach(var child in r.getHijos())
            {
               found = _buscarDominio(child,d,found);
            }

            return found;      
        }
  
    }
}
