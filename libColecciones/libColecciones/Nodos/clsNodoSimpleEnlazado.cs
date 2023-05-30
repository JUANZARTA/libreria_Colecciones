using Servicios.Colecciones.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoSimpleEnlazado<Tipo>: clsNodo<Tipo>, iNodoSimpleEnlazado<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoSimpleEnlazado<Tipo> atrSiguiente;
        #endregion
        #region Operaciones
        public clsNodoSimpleEnlazado() {}
        public clsNodoSimpleEnlazado(Tipo prmItem) : base(prmItem) {}
        public clsNodoSimpleEnlazado<Tipo> siguiente
        {
            get { return atrSiguiente; }
            set { atrSiguiente = value; }
        }
        #endregion
        #region Accesores(interface)
        public clsNodoSimpleEnlazado<Tipo> darSiguiente()
        {
            return atrSiguiente;
        }
        #endregion
        #region Conectores
        public bool conectar(clsNodoSimpleEnlazado<Tipo> prmNodo)
        {
            if (prmNodo != null)
            {
                if (atrSiguiente == null)
                    atrSiguiente = prmNodo;
                else
                {
                    prmNodo.atrSiguiente = atrSiguiente;
                    atrSiguiente = prmNodo;
                }
                return true;
            }
            return false;
        }
        public bool desconectar(ref clsNodoSimpleEnlazado<Tipo> prmNodo)
        {
            if(prmNodo != null)
            {
                if (atrSiguiente != null)
                {
                   // atrSiguiente = prmNodo.atrSiguiente;

                    prmNodo = atrSiguiente;
                    prmNodo.atrSiguiente = null;
                    atrSiguiente = atrSiguiente.atrSiguiente;
                    //atrSiguiente = null;
                //prmNodo.atrSiguiente = null;
                    return true;
                }
                prmNodo = null;
            }
           
            return false;
        }
        public void ponerSiguiente(clsNodoSimpleEnlazado<Tipo> prmSiguiente)
        {
            atrSiguiente = prmSiguiente;
        }

        #endregion

    }
}
 