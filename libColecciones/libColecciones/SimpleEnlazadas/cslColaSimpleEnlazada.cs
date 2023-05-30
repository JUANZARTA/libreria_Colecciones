using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;
namespace Servicios.Colecciones.SimpleEnlazadas
{
    public class clsColaSimpleEnlazada<Tipo> :clsTadSimpleEnlazado<Tipo>, iCola<Tipo>, iTadSimpleEnlazado<Tipo> where Tipo : IComparable
    {
        #region Atributos
       //ubicacion: clsTadSimpleEnlazada,clsTad
        #endregion
        #region Costructores
        public clsColaSimpleEnlazada()
        {
            atrPrimero = new clsNodoSimpleEnlazado<Tipo>();
            atrUltimo = new clsNodoSimpleEnlazado<Tipo>();
        }
        #endregion
        #region Crud
        public bool encolar(Tipo prmItem)
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
        public bool desencolar(ref Tipo prmItem)
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
