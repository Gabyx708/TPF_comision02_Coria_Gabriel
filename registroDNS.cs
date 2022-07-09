using System;
using System.Collections.Generic;
using System.Text;

namespace TPF_dns
{
    class registroDNS
    {
        private string tag;
        private string IP;
        private string service;
        private bool ordenSup;

        public registroDNS(string t,string ip,string s)
        {
            tag = t;
            IP = ip;
            service = s;
            ordenSup = false;
        }

        public void setService(string s)
        {
            service = s;
        }

        public void setIP(string p)
        {
            IP = p;
        }

        public void setTsg(string t)
        {
            tag = t;
        }

        public void setOrden(bool o)
        {
            ordenSup = o;
        }

        public override string ToString()
        {
            /*return "\n(Etiqueta: " + tag + "|| IP: " + IP + "|| servicio: " + service+"||)\n";*/
            return "("+tag+")";
        }

        public string getServi()
        {
            return service;
        }
        
        public string getIP()
        {
            return IP;
        }

        public string getTag()
        {
            return tag;
        }

        public bool getOrd()
        {
            return ordenSup;
        }

        public string Presentar()
        {
            return "\nURL: " + tag + "\nIP: " + IP + "\nServicio: " + service+"\n";
        }
    }
}
