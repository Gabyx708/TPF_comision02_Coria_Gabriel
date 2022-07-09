using System;
using System.Collections.Generic;
using System.Collections;
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
            c.setOrden(true);
            n.setOrden(true);
            o.setOrden(true);
          
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

        /*------LOGICA DE AGREGADO--------*/
        public void addRegister(registroDNS dns)
        {
           string[] dominios = dns.getTag().Split('.');

            /*nuevo hijo para agregar al arbol*/
            ArbolGeneral<registroDNS> newReg = new ArbolGeneral<registroDNS>(dns);
            _add(dominios,root,newReg,dominios.Length - 1);
        }

        private void _add(string[] dom, ArbolGeneral<registroDNS> r, ArbolGeneral<registroDNS> nuev, int contador)
        {
            string tag = dom[contador];
            ArbolGeneral<registroDNS> arbAux = null;

            foreach (var hijo in r.getHijos())
            {
                if (tag == hijo.getDatoRaiz().getTag())
                {
                    arbAux = hijo;
                    break;
                }
            }

            if (arbAux == null)
            {
                registroDNS dnsAux = new registroDNS(dom[contador], "", "");
                arbAux = new ArbolGeneral<registroDNS>(dnsAux);
                dnsAux.setOrden(true);
                r.agregarHijo(arbAux);
            }

            contador = contador - 1;

            if (contador == 0)
            {
                arbAux.agregarHijo(nuev);
            }

            if (contador > 0)
            {
                _add(dom, arbAux, nuev, contador);
            }
        }

        /*--METODOS DE UTILIDAD-----*/
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


        /*-----LOGICA DE ELIMINACION---*/

        public void eliminDom(string dominio)
        {
            _eliminDom(dominio,dnsSistema());
        }

        private void _eliminDom(string dom,ArbolGeneral<registroDNS> ar)
        {
            foreach (var child in ar.getHijos())
            {
                if (child.getDatoRaiz().getTag() == dom)
                {
                    ar.eliminarHijo(child);
                    break;
                }
                _eliminDom(dom,child);
            }
        }

        /*---LOGICA DE BUSQUEDA DE SUBDOMINIOS---*/
        public ArbolGeneral<registroDNS> busquedaSubdominio(string sub)
        {
            var arbol = _busquedaSubdominio(sub,dnsSistema(),null);
            return arbol;
        }
        private ArbolGeneral<registroDNS> _busquedaSubdominio(string sub,ArbolGeneral<registroDNS> r,ArbolGeneral<registroDNS> found)
        {
            if( r.getDatoRaiz().getTag() == sub)
            {
                found = r;
                return found;
            }

            foreach (var child in r.getHijos())
            {
                found = _busquedaSubdominio(sub, child,found);          
            }
            return found;
        }
        

        /*-----LOGICA DE PROFUNDIDAD-----*/

        public void profundidad(int pr)
        {
           var cola = _profundidad(pr);

            int contEqui=0, contSup=0;

            while (!cola.esVacia())
            {
                var ele =cola.desencolar();
                
                if(ele.getDatoRaiz().getOrd())
                {
                    contSup++;
                }

                if(ele.esHoja())
                {
                    contEqui++;
                }

            }

            Console.WriteLine("****************************************************");
            Console.WriteLine("equipos: "+contEqui+" dominios superiores: "+contSup);
            Console.WriteLine("****************************************************");
        }
        private Cola<ArbolGeneral<registroDNS>>  _profundidad(int pr)
        {
            Cola<ArbolGeneral<registroDNS>> cola = new Cola<ArbolGeneral<registroDNS>>();
            ArbolGeneral<registroDNS> arbolAux;

            cola.encolar(root);
            cola.encolar(null);
            int contNIvel = 0;

            while (!cola.esVacia())
            {
                arbolAux = cola.desencolar();

                if (arbolAux == null)
                {
                    contNIvel++;

                    if(contNIvel == pr)
                    {
                        return cola;
                    }

                    if (!cola.esVacia())
                        cola.encolar(null);
                }
                else
                {
                    foreach (var hijo in arbolAux.getHijos())
                    {
                        cola.encolar(hijo);
                    }
                }
            }

            return null;
        }


        
    }
}
