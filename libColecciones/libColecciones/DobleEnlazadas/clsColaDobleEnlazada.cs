using System;
using Servicios.Colecciones;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;
namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsColaDobleEnlazada<Tipo>:clsTadDobleEnlazado<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        #region Atributos
        //ubicacion:clsTadDobleEnlazada,
        #endregion
        #region Constructor
        public clsColaDobleEnlazada()
        {
            atrPrimero = new clsNodoDobleEnlazado<Tipo>();
            atrUltimo = new clsNodoDobleEnlazado<Tipo>();

        }
        #endregion
        #region Crud
        public bool encolar(Tipo prmItem)
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
                   atrUltimo.darAnterior();
                    atrLongitud++;
                    return true;
                }
            }
            return false;
        }
        //public bool desencolar(ref Tipo prmItem)
        //{
        //    if (atrLongitud != 0)
        //    {
        //        prmItem = atrPrimero.darItem();
        //        if (atrLongitud == 1)
        //        {
        //            atrPrimero = null;
        //            atrUltimo = null;
        //            atrLongitud--;
        //            return true;
        //        }
        //        else
        //        {
        //            atrPrimero = atrPrimero.darSiguiente();
        //            //atrPrimero.darSiguiente().conectar(atrPrimero.darSiguiente());
        //            //atrPrimero.desconectar(ref atrPrimero);
        //            atrUltimo.darAnterior();
        //            atrLongitud--;
        //            return true;
        //        }

        //    }
        //    else if (atrLongitud == 0)
        //    {
        //        atrPrimero = null;
        //        atrUltimo = null;
        //        return false;
        //    }
        //    return false;
        //}
        //public bool desencolar(ref Tipo prmItem)
        //{
        //    if (atrLongitud != 0 && atrPrimero != null)
        //    {
        //        if (atrPrimero.darSiguiente() == null)
        //        {
        //            prmItem = atrUltimo.darItem();
        //            atrPrimero = null;
        //            atrUltimo = null;
        //            atrLongitud--;
        //        }
        //        else
        //        {
        //            prmItem = atrPrimero.darItem();
        //            atrPrimero.desconectar(ref atrPrimero);
        //            atrLongitud--;

        //            if (atrLongitud == 0)
        //            {
        //                atrPrimero = null;
        //                atrUltimo = null;
        //            }
        //        }

        //        return true;
        //    }
        //    else if (atrLongitud == 0)
        //    {
        //        atrPrimero = null;
        //        atrUltimo = null;

        //    }
        //    return false;
        //}
        //public bool desencolar(ref Tipo prmItem)
        //{
        //    if (atrLongitud != 0 && atrPrimero != null)
        //    {
        //        if (atrPrimero.darSiguiente() == null)
        //        {
        //            prmItem = atrUltimo.darItem();
        //            atrPrimero = null;
        //            atrUltimo = null;
        //            atrLongitud--;
        //        }
        //        else
        //        {
        //            prmItem = atrPrimero.darItem();

        //            atrPrimero.desconectar(ref atrPrimero);                   
        //            atrLongitud--;

        //            if (atrLongitud == 0)
        //            {
        //                atrPrimero = null;
        //                atrUltimo = null;
        //            }
        //        }

        //        return true;
        //    }
        //    else if (atrLongitud == 0)
        //    {
        //        atrPrimero = null;
        //        atrUltimo = null;

        //    }
        //    return false;
        //}
        public bool desencolar(ref Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> nuevo = new clsNodoDobleEnlazado<Tipo>();
            if (atrLongitud != 0)
            {
                prmItem = atrPrimero.darItem();
                if (atrLongitud == 1)
                {
                    atrPrimero = null;
                    atrUltimo = null;
                    atrLongitud--;
                    return true;
                }
                else
                {
                    var aux = atrPrimero.darAnterior();
                    aux = null;
                    atrPrimero = atrPrimero.darSiguiente();

                   
                  
                    //atrPrimero = atrPrimero.darAnterior();
                    atrLongitud--;
                    return true;
                }

            }
            else if (atrLongitud == 0)
            {
                atrPrimero = null;
                atrUltimo = null;
                return false;
            }
            return false;
        }
        public bool revisar(ref Tipo prmItem)
        {
            if (atrLongitud == 0)
            {
                return false;
            }

            prmItem = darPrimero().darItem();
            atrUltimo.darAnterior();

            return true;
        }
        #endregion

    }
}
