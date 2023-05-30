using System;
using Servicios.Colecciones;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;
namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsPilaDobleEnlazada<Tipo> :clsTadDobleEnlazado<Tipo>, iPila<Tipo> where Tipo : IComparable
    {
        #region Atributos
        //ubicacion:clsTadDobleEnlazada,
        #endregion
        #region Constructores
        public clsPilaDobleEnlazada()
        {
            atrPrimero = new clsNodoDobleEnlazado<Tipo>();
            atrUltimo = new clsNodoDobleEnlazado<Tipo>();
        }
        #endregion
        #region Cruds
        public bool apilar(Tipo prmItem)
        //{
        //    clsNodoDobleEnlazado<Tipo> nuevo = new clsNodoDobleEnlazado<Tipo>();
        //    if (prmItem != null)
        //    {
        //        if (atrLongitud == 0)
        //        {
        //            atrPrimero.poner(prmItem);
        //            atrUltimo = atrPrimero;
        //            //atrPrimero.darAnterior().conectar(null);
        //            //atrUltimo.darSiguiente().conectar(null);
        //            atrLongitud++;
        //            return true;
        //        }
        //        else
        //        {
        //            nuevo.poner(prmItem);
        //            nuevo.conectar(atrPrimero);
        //            atrPrimero = nuevo;
        //            atrPrimero.conectar(atrPrimero.darSiguiente());
        //            //atrPrimero.conectar(atrPrimero.darAnterior());
        //            atrLongitud++;
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        {
            clsNodoDobleEnlazado<Tipo> nuevo = new clsNodoDobleEnlazado<Tipo>();
            if (prmItem != null)
            {
                if (atrLongitud == 0)
                {
                    atrPrimero.poner(prmItem);
                    atrUltimo = atrPrimero;
                    var aux1=atrPrimero.darSiguiente();
                    aux1 = null;
                    var aux2 = atrPrimero.darAnterior();
                    aux2 = null;
                    atrLongitud++;
                    return true;
                }
                else
                {
                    nuevo.poner(prmItem);
                    //if(atrUltimo==atrPrimero)

                    nuevo.conectar(atrPrimero);
                    atrPrimero = nuevo;
                    //atrPrimero.darAnterior();
                    atrLongitud++;
                    return true;
                }
            }
            return false;
        }
        public bool desapilar(ref Tipo prmItem)
        {
            if (atrLongitud != 0)
            {
                prmItem = atrPrimero.darItem();
                atrPrimero.darSiguiente();
                if (atrLongitud == 1)
                {
                    atrPrimero = null;
                    atrUltimo = null;
                    atrLongitud--;
                    return true;
                }
                else
                {
                   
                    atrPrimero = atrPrimero.darSiguiente();
                    atrPrimero.darSiguiente();
                    
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
            atrPrimero.darSiguiente();
            atrPrimero.darAnterior();
            return true;
        }

        #endregion
    }
}
