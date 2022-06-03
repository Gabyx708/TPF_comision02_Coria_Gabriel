using System;
using System.Collections.Generic;

namespace dataEstruct
{
	public class ArbolGeneral<T> 
	{
		
		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Add(hijo);
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Remove(hijo);
		}
	
		public bool esHoja() {
			return this.getHijos().Count == 0;
		}
	
		//metodo para saber la altura del arbol
		public int altura() {

            if (this.esHoja())
            {
				return 0;
            }
            else
            {
				int alturaMaxi = 0;

                foreach (var hijo in this.getHijos())
                {
					if(hijo.altura() > alturaMaxi)
                    {
						alturaMaxi = hijo.altura();
                    }
                }

				return alturaMaxi+1;
            }
			
		}


		public int nivel(T dato) {

			Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();

			ArbolGeneral<T> arbolAux;

			cola.encolar(this);
			cola.encolar(null);

			int nivelCont = 0;

            while (!cola.esVacia())
            {
				arbolAux = cola.desencolar();

                if (arbolAux == null)
                {
					nivelCont++;

					if (!cola.esVacia())
						cola.encolar(null);
				}
                else
                {
                    if (arbolAux.include(dato))
                    {
						return nivelCont;
                    }
                    else
                    {
                        foreach (var hijo in arbolAux.getHijos())
                        {
							cola.encolar(hijo);
                        }
                    }
                }
							
                 
            }

			return -1;
		}

		public bool include(T dato)
        {
			return dato.Equals(this.getDatoRaiz());
        }

		public int ancho()
        {
			Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();

			ArbolGeneral<T> arbolAux;

			cola.encolar(this);
			cola.encolar(null);

			int contNodos = 0; //cuenta los nodos por nivel
			int ancho = 0; //cuenta el ancho del arbol

            while (!cola.esVacia())
            {
				arbolAux = cola.desencolar();

                if (arbolAux == null) //si el arbol es un separador
                {
                    //me quedo con el ancho cuando desencolo un separador
                    if (contNodos > ancho)
                    {
						ancho = contNodos;
						contNodos = 0;
                    }

                    if (!cola.esVacia())
							cola.encolar(null);

				}else
                    {
						contNodos++;

                        foreach (var hijo in arbolAux.getHijos())
                        {
							cola.encolar(hijo);
                        }
                    }
                }

			return ancho;
		}

		//recorridos

		public void preOrden()
        {
           	Console.Write("nodo: "+this.dato +"->");

			foreach (var hijo in this.getHijos())
			{
				hijo.preOrden();
			}
		}

		public void postOrden()
		{

			foreach (var hijo in this.getHijos())
			{
				hijo.postOrden();
			}

			Console.Write("nodo->" + this.dato + "  ");
		}

		public void inOrden()
        {
            if (!this.esHoja())
            {
				this.hijos[0].inOrden();
            }

			Console.Write("nodo->" + this.dato + "  ");

            for (int i=1;i< this.hijos.Count; i++)
            {
				this.hijos[i].inOrden();
            }
        }

		public void porNiveles()
        {
			Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolAux;

			cola.encolar(this);
			cola.encolar(null);
			int contNIvel = 0;

            while (!cola.esVacia())
            {
				arbolAux = cola.desencolar();

                if (arbolAux == null)
                {
					contNIvel++;
					Console.Write(" NODOS DEL NIVEL:" + (contNIvel-1) + "\n");
					
					if (!cola.esVacia())
						cola.encolar(null);
                }else{
					Console.Write("nodo:" + arbolAux.dato+" ");

					foreach (var hijo in arbolAux.getHijos())
					{
						cola.encolar(hijo);
					}
                }		
			} 
         }

		//ejercicio 5
		public void caudal(float caudal)	//nota para mi: es un recorrido preorden!! y no te diste cuenta jeje
        {
			Console.WriteLine("caudal del nodo " + this.getDatoRaiz() + " ---- " + caudal.ToString("N2"));

			caudal = caudal / this.getHijos().Count;

			foreach (var hijo in this.getHijos())
			{
				hijo.caudal(caudal);

			}
		}

	}

}




