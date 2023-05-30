using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo> : iNodo<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private Tipo atrItem;
        #endregion
        //public Tipo Item
        //{
        //    get { return atrItem; }
        //    set { atrItem = value; }
        //}        
        #region Accesores
        public Tipo darItem()
        {
            return atrItem;
           
        }
        #endregion
        #region Mutador
        public void poner(Tipo prmItem)
        {
            atrItem = prmItem;
        }
        #endregion
        #region constructores
        public clsNodo()
        {
            atrItem = default(Tipo);
            
        }
        public clsNodo(Tipo prmItem)
        {
            atrItem = prmItem;
        }
        #endregion

    }
}
