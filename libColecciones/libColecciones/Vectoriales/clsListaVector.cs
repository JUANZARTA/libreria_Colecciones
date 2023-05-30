using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;

namespace Servicios.Colecciones.Vectoriales
{
   public class clsListaVector<Tipo>: clsTadVectorial<Tipo>, iLista<Tipo> where Tipo: IComparable
    {
        #region Atributos
        #region Propios
       //ubicacion: clsTadVectorial
        #endregion
        #endregion
        #region Metodos
        #region Costructores
        public clsListaVector()
        {

        }
        public clsListaVector(int prmCapacidad):base(prmCapacidad)
        {
            

        }
        #endregion   
        #region Cruds
       public bool agregar(Tipo prmItem){
            if (atrLongitud < atrCapacidad)
            {
                
                atrItems[atrLongitud] = prmItem;
                atrLongitud++;
                return true;
            }
            return false;
        }
        public bool insertar(int prmIndice, Tipo prmItem)
        { 
            if (atrLongitud < atrCapacidad)
            {
                atrLongitud++;
                for (int i = atrLongitud - 1; i >= prmIndice; i--)
                {
                    atrItems[i+1] = atrItems[i];
               }
                atrItems[prmIndice] = prmItem;
                return true;
            }
            if (prmIndice - 1 > atrLongitud)
                return false;
            return false; 
        }
        public bool remover(int prmIndice, ref Tipo prmItem)
        {
            if (atrLongitud > 0 & atrLongitud <= atrCapacidad)
            {
                if (prmIndice <= atrLongitud)
                {
                    prmItem = atrItems[prmIndice];
                    for(int i=prmIndice;i<atrLongitud-1;i++)
                    {
                        atrItems[i]= atrItems[i+1];
                    }
                    atrLongitud--;
                    return true;
                }
            }
            return false;
        }
        public bool modificar(int prmIndice, Tipo prmItem)
        {
            if (prmIndice <= -1)
            {
                return false;
            }
            if (prmIndice > atrLongitud)
                return false;
            if (prmIndice < atrLongitud)
            {

                atrItems[prmIndice] = prmItem;

                return true;
            }
            if (prmIndice <= -1)
            {
                return false;
            }
            return false;
        }
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
           
            for (int varTest = 0; varTest < atrLongitud; varTest++)
            {
                if (atrItems[varTest].Equals(atrItems[prmIndice]))
                {
                    prmItem = atrItems[0];
                    prmItem = atrItems[prmIndice];
                    return true;
                }
            }
            return false;
        }
        public bool encontrar(Tipo prmItem,ref int prmIndice)
        {
           
                for( int varIndice=0;varIndice<atrLongitud;varIndice++)
            {
                if(atrItems[varIndice].Equals(prmItem))
                {
                    prmIndice = varIndice;
                    return true;
                }
               
            }return false;
        }
        #endregion
        #endregion
        #region Complementos
        public bool Desplazar()

        {
            for (int i = atrLongitud; i > 0; i--)
                atrItems[i] = atrItems[i - 1];

            return true;

        }
        #endregion
 

    }

}

 
            
                 
            
