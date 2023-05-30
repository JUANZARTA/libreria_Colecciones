using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
namespace Servicios.Colecciones.Vectoriales 
{
    public class clsColaVector<Tipo> : clsTadVectorial<Tipo>,iCola<Tipo> where Tipo:IComparable
    {
        #region Atributos
        //ubicacion: clsTadVectorial
        #endregion
        #region Metodos
        #region Costructores
        public clsColaVector()
        {

        }
        public clsColaVector(int prmCapacidad): base(prmCapacidad)
        {
        
        }
        #endregion
        #region CRUDS
        public bool encolar(Tipo prmItem)
        {
            
            if (atrLongitud < atrCapacidad)
            {
                atrItems[atrLongitud] = prmItem;
                atrLongitud++;
                return true;
            }
            
            return false;
        }
        public bool desencolar(ref Tipo prmItem)
        { int contador = 0;
            if (atrLongitud >= 1)
            {
                prmItem = atrItems[0 + contador];
                contador++;
                for (int i = 1; i < atrLongitud; i++)
                    atrItems[i - 1] = atrItems[i];
                atrLongitud--;
               
                return true;
            }
            
          
            return false; 
            
        }       
        public bool revisar(ref Tipo prmItem)
        {
            if (atrLongitud != 0)
            {
                for (int i = 0; i <= atrLongitud; i++)
                {
                    prmItem = atrItems[i];

                    return true;
                }
            }

            return false;
        }
        #endregion
        #endregion
    }
}
    