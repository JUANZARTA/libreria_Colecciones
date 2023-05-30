using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Tads
{
    public class clsTadSimpleEnlazado<Tipo>: clsTad<Tipo>, iTadSimpleEnlazado<Tipo> where Tipo: IComparable
    {
        #region Atributos
        protected clsNodoSimpleEnlazado<Tipo> atrPrimero;
        protected clsNodoSimpleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Costructores
        public clsTadSimpleEnlazado()
        {
            atrPrimero = new clsNodoSimpleEnlazado<Tipo>();
            atrUltimo = new clsNodoSimpleEnlazado<Tipo>();           
        }
        #endregion
        #region Operaciones
        public clsNodoSimpleEnlazado<Tipo> darPrimero()
        {
            return atrPrimero;
        }
        public clsNodoSimpleEnlazado<Tipo> darUltimo()
        {
            return atrUltimo;
        }
        #endregion
    }
}
