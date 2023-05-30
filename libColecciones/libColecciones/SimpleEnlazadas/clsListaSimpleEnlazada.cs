using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;
namespace Servicios.Colecciones.SimpleEnlazadas
{
    public class clsListaSimpleEnlazada<Tipo> :clsTadSimpleEnlazado<Tipo>, iLista<Tipo> where Tipo:IComparable
    {
        #region Atributos
        //ubicacion: clsTadSimpleEnlazada
        #endregion
        #region Costructores
        public clsListaSimpleEnlazada()
        {
            atrPrimero = new clsNodoSimpleEnlazado<Tipo>();
            atrUltimo = new clsNodoSimpleEnlazado<Tipo>();

        }
        #endregion
        #region CRUDS
        public bool agregar(Tipo prmItem)
        {
            clsNodoSimpleEnlazado<Tipo> nuevo = new clsNodoSimpleEnlazado<Tipo>();
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
                clsNodoSimpleEnlazado<Tipo> nuevo = new clsNodoSimpleEnlazado<Tipo>();
                if (prmIndice == atrLongitud - 1 && prmIndice != 0)
                {

                    nuevo.poner(prmItem);
                    nuevo.conectar(atrUltimo);
                    prmIndice = prmIndice - 1;
                    nuevo.conectar(atrUltimo.darSiguiente());
                    atrPrimero.darSiguiente().darSiguiente().darSiguiente().darSiguiente().conectar(nuevo);
                    //atrUltimo = nuevo.darSiguiente();
                    atrUltimo.desconectar(ref nuevo);
                    atrLongitud++;

                    return true;
                }
                else
                if (prmIndice == 1)
                {
                    nuevo.poner(prmItem);
                    atrPrimero = nuevo.darSiguiente();
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
            clsNodoSimpleEnlazado<Tipo> nuevoAux = new clsNodoSimpleEnlazado<Tipo>();
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
            clsNodoSimpleEnlazado<Tipo> nuevo = new clsNodoSimpleEnlazado<Tipo>();
            clsNodoSimpleEnlazado<Tipo> nuevoAux = new clsNodoSimpleEnlazado<Tipo>();
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
            clsNodoSimpleEnlazado<Tipo> nuevoAux = new clsNodoSimpleEnlazado<Tipo>();
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
                clsNodoSimpleEnlazado<Tipo> nuevo = new clsNodoSimpleEnlazado<Tipo>();

                if (prmIndice == atrLongitud - 1)
                {
                    prmItem = atrUltimo.darItem();

                    for (int i = 0; i < prmIndice; i++)
                    {
                        nuevo.conectar(atrPrimero.darSiguiente());
                    }
                    nuevo.desconectar(ref atrUltimo);
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
                        nuevo.conectar(atrPrimero);
                        nuevo.desconectar(ref atrPrimero);
                        nuevo = atrPrimero.darSiguiente();
                        nuevo = null;

                        atrLongitud--;

                    }
                    else
                    {
                        if (prmIndice == atrLongitud)
                        {
                            prmItem = atrUltimo.darItem();
                            atrUltimo = null;
                            atrLongitud--;
                            return true;
                        }
                        for (int i = 0; i < prmIndice; i++)
                        {
                            prmItem = atrPrimero.darSiguiente().darItem();
                            nuevo = atrPrimero.darSiguiente();
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