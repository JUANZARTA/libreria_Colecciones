using System;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Interfaces;
namespace Servicios.Colecciones.Tads
{
    public class clsTadDobleEnlazado<Tipo>:clsTad<Tipo>, iTadDobleEnlazado<Tipo> where Tipo:IComparable
    {
        #region Atributos
        protected clsNodoDobleEnlazado<Tipo> atrPrimero;
        protected clsNodoDobleEnlazado<Tipo> atrUltimo;
        #endregion
        #region Constructor
        public clsTadDobleEnlazado()
        {
            atrPrimero = new clsNodoDobleEnlazado<Tipo>(); 
            atrUltimo = new clsNodoDobleEnlazado<Tipo>(); 
        }
        #endregion
        #region Metodos
        public clsNodoDobleEnlazado<Tipo> darPrimero()
        {
            return atrPrimero;
        }

        public clsNodoDobleEnlazado<Tipo> darUltimo()
        {
            return atrUltimo;
        }
        #endregion

    }
}
