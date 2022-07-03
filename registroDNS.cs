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

        public registroDNS(string t,string ip,string s)
        {
            tag = t;
            IP = ip;
            service = s;
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

        public string Presentar()
        {
            return "\nURL: " + tag + "\nIP: " + IP + "\nServicio: " + service+"\n";
        }
    }
}
