using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;



namespace Servicios.Colecciones.SimpleEnlazadas
{
    public class clsPilaSimpleEnlazada<Tipo> :clsTadSimpleEnlazado<Tipo>, iPila<Tipo>, iTadSimpleEnlazado<Tipo> where Tipo : IComparable
    {
        #region Atributos
        //ubicacion: clsTadSimpleEnlazada
        #endregion
        #region Costructores
        public clsPilaSimpleEnlazada()
        {
            atrPrimero = new clsNodoSimpleEnlazado<Tipo>();
            atrUltimo = new clsNodoSimpleEnlazado<Tipo>(); 

        }
        #endregion
        #region Crud
        public bool apilar(Tipo prmItem)
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
                else
                {
                    nuevo.poner(prmItem);
                    nuevo.conectar(atrPrimero);
                    atrPrimero = nuevo;
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

            return true;
        }
        #endregion
  

    }
}
