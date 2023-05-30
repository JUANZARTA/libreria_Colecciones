using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Colecciones;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsListaDobleEnlazada<Tipo> :clsTadDobleEnlazado<Tipo>, iLista<Tipo> where Tipo : IComparable
    {
        #region Atributos
        //ubicacion:clsTadDobleEnlazada,
        #endregion
        #region Constructor
        public clsListaDobleEnlazada()
        {
            atrPrimero = new clsNodoDobleEnlazado<Tipo>();
            atrUltimo = new clsNodoDobleEnlazado<Tipo>();

        }
        #endregion
        #region CRUDS
        public bool agregar(Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> nuevo = new clsNodoDobleEnlazado<Tipo>();
            if (prmItem != null)
            {
                if (atrLongitud == 0)
                {
                    atrPrimero.poner(prmItem);
                    atrUltimo = atrPrimero;
                    atrLongitud++;
                    return true;
                }
                else if (atrLongitud == 1)
                {
                    nuevo.poner(prmItem);
                    atrUltimo = nuevo;
                    atrPrimero.conectar(atrUltimo);
                    atrLongitud++;
                    return true;
                }
                else
                {
                    nuevo.poner(prmItem);
                    atrUltimo.conectar(nuevo);
                    atrUltimo = nuevo;
                    atrPrimero.darSiguiente();
                    atrUltimo.darAnterior();
                    atrLongitud++;
                    return true;
                }
            }
            return false;
        }
        public bool insertar(int prmIndice, Tipo prmItem)
        {
            if (atrLongitud != 0)
            {
                clsNodoDobleEnlazado<Tipo> nuevo = new clsNodoDobleEnlazado<Tipo>();
                if (prmIndice == atrLongitud - 1 && prmIndice != 0)
                {

                    nuevo.poner(prmItem);
                    var aux2 = atrUltimo.darAnterior();
                    //nuevo.conectar(aux2);
                    atrUltimo.darAnterior().conectar(nuevo);
                    nuevo.conectar(atrUltimo);
                    //nuevo.darSiguiente().conectar(atrUltimo);
                    //prmIndice = prmIndice - 1;
                    //nuevo.conectar(atrUltimo.darSiguiente());
                    //atrPrimero.darSiguiente().darSiguiente().darSiguiente().darSiguiente().conectar(nuevo);

                    //atrUltimo = nuevo.darSiguiente();
                    //nuevo.darAnterior().desconectar(ref atrUltimo);
                    //var aux1 = nuevo.darAnterior();
                    //nuevo.darSiguiente().desconectar(ref aux1);                    
                    //atrPrimero.darSiguiente();
                    //atrUltimo.darAnterior();
                    atrLongitud++;
                    //nuevo.poner(prmItem);
                    //nuevo.conectar(atrUltimo.darAnterior());
                    //nuevo.conectar(atrUltimo);
                    ////atrUltimo.darAnterior().darAnterior().desconectar(ref atrUltimo);
                    //var aux=atrUltimo.darAnterior().darAnterior();
                    ////atrUltimo.desconectar(ref aux);
                    //atrLongitud++;


                    return true;
                }
                else
                if (prmIndice == 1)
                {
                    nuevo.poner(prmItem);
                    atrPrimero = nuevo.darSiguiente();
                    atrPrimero.darSiguiente();
                    atrUltimo.darAnterior();
                    atrLongitud++;
                }
                else
                if (prmIndice == 0)
                {
                    nuevo.poner(prmItem);
                    nuevo.conectar(atrPrimero);
                    atrPrimero = nuevo;
                    atrLongitud++;

                }
                else
                {
                    for (int i = 0; i <= prmIndice; i++)
                    {
                        nuevo.poner(prmItem);
                        nuevo = atrPrimero.darSiguiente();
                    }
                    atrPrimero.darSiguiente();
                    atrUltimo.darAnterior();
                    atrLongitud++;
                }
                return true;
            }
            else if (atrLongitud == 0)
            {
                atrPrimero = null;
                atrUltimo = null;
                return false;
            }

            return false;
        }
        public bool encontrar(Tipo prmItem, ref int prmIndice)
        {
            clsNodoDobleEnlazado<Tipo> nuevoAux = new clsNodoDobleEnlazado<Tipo>();
            if (atrLongitud > 100)
            {
                return false;
            }
            if (prmItem != null)
            {   
                if (atrLongitud == 1 && prmItem.Equals(atrPrimero.darItem()))
                {
                    prmIndice = 0;
                    return true;
                }
                else
                {
                    nuevoAux = atrPrimero;
                    int varIndice = 0;
                    while (varIndice < atrLongitud)
                    {
                        if (prmItem.Equals(nuevoAux.darItem()))
                        {
                            prmIndice = varIndice;
                            return true;
                        }
                        varIndice++;
                        nuevoAux = nuevoAux.darSiguiente();
                    }
                    atrPrimero.darSiguiente();
                    atrUltimo.darAnterior();
                    return false;
                }
            }
            else if (atrLongitud == 0)
            {
                return false;
            }
            return false;
        }
        public bool modificar(int prmIndice, Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> nuevo = new clsNodoDobleEnlazado<Tipo>();
            clsNodoDobleEnlazado<Tipo> nuevoAux = new clsNodoDobleEnlazado<Tipo>();
            if (prmItem != null)
            {
                if (atrLongitud == 1)
                {
                    nuevo.poner(prmItem);
                    atrUltimo = nuevo;
                    atrPrimero = atrUltimo;
                    return true;
                }
                else
                {
                    nuevoAux = atrPrimero;
                    int varIndice = 0;
                    while (varIndice < atrLongitud)
                    {
                        if (varIndice == prmIndice)
                        {
                            nuevoAux.poner(prmItem);
                            return true;
                        }
                        varIndice++;
                        nuevoAux = nuevoAux.darSiguiente();
                    }
                    atrPrimero.darSiguiente();
                    atrUltimo.darAnterior();

                }
            }
            else if (atrLongitud == 0)
            {
                return false;
            }

            return false;
        }
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> nuevoAux = new clsNodoDobleEnlazado<Tipo>();
            if (prmItem != null)
            {
                if (atrLongitud == 1 && prmIndice == 0)
                {
                    prmItem = atrPrimero.darItem();
                    return true;
                }
                else
                {
                    nuevoAux = atrPrimero;
                    int varIndice = 0;
                    while (varIndice < atrLongitud)
                    {
                        if (prmIndice == varIndice)
                        {
                            prmItem = nuevoAux.darItem();
                            return true;
                        }
                        varIndice++;
                        nuevoAux = nuevoAux.darSiguiente();
                    }
                    atrPrimero.darSiguiente();
                    atrUltimo.darAnterior();
                    return true;
                }
            }
            else if (atrLongitud == 0)
            {
                return false;
            }
            return false;
        }
        public bool remover(int prmIndice, ref Tipo prmItem)
        {
            if (atrLongitud != 0)
            {
                clsNodoDobleEnlazado<Tipo> nuevo = new clsNodoDobleEnlazado<Tipo>();

                if (prmIndice == atrLongitud - 1)
                {
                    prmItem = atrUltimo.darItem();
                    nuevo = atrUltimo.darAnterior();
                    atrUltimo = atrUltimo.darAnterior();
                    var aux = atrUltimo.darSiguiente();
                    aux = null;
                    //nuevo.desconectar(ref aux);
                   // nuevo = null;
                    //for (int i = 0; i < prmIndice; i++)
                    //{
                    //    nuevo.conectar(atrPrimero.darSiguiente());
                    //}

                    ////atrPrimero.darSiguiente();
                    ////atrUltimo.darAnterior();
                    //nuevo.desconectar(ref atrUltimo);
                    atrLongitud--;
                    if (atrLongitud == 0)
                    {
                        atrPrimero = null;
                        atrUltimo = null;
                    }
                    return true;
                }

                else
                {
                    if (prmIndice == 1)
                    {
                        prmItem = atrPrimero.darSiguiente().darItem();
                        nuevo = atrPrimero;
                        var aux = atrPrimero.darSiguiente();
                        aux = null;
                        nuevo.conectar(atrPrimero.darSiguiente().darSiguiente());

                        
                       // atrPrimero.conectar(nuevo.darAnterior());
                        //nuevo.desconectar(ref atrPrimero);
                        //nuevo = atrPrimero.darSiguiente();
                        //nuevo.conectar(atrPrimero.darSiguiente().darSiguiente());
                        //nuevo.desconectar(ref atrPrimero);

                        //nuevo = null;

                        atrLongitud--;

                    }
                    else
                    {
                        if (prmIndice == atrLongitud)
                        {
                            prmItem = atrUltimo.darItem();
                            atrUltimo.darAnterior();
                            atrUltimo = null;
                            atrLongitud--;
                            return true;
                        }
                        for (int i = 0; i < prmIndice; i++)
                        {
                            prmItem = atrPrimero.darSiguiente().darItem();
                            nuevo = atrPrimero.darSiguiente();
                            atrPrimero.darSiguiente();
                            nuevo = null;
                        }
                        atrLongitud--;
                    }
                }
                return true;
            }
            atrPrimero = null;
            atrUltimo = null;
            return false;
        }
        #endregion

    }


}


