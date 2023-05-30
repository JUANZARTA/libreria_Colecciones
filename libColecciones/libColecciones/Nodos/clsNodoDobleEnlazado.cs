using Servicios.Colecciones.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo>, iNodoDobleEnlazado<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;
        #endregion
        #region constructores
        public clsNodoDobleEnlazado() {  }
        public clsNodoDobleEnlazado(Tipo prmItem) : base(prmItem){  }
        #endregion
        #region Accesores
        public clsNodoDobleEnlazado<Tipo> darAnterior()
        {
            return atrAnterior;
        }
        public clsNodoDobleEnlazado<Tipo> darSiguiente()
        {
            return atrSiguiente;
        }
        #endregion
        //public clsNodoDobleEnlazado<Tipo> Anterior
        //{
        //    get { return atrAnterior; }
        //    set { atrAnterior = value; }
        //}
        #region conectores
        //public bool conectar(clsNodoDobleEnlazado<Tipo> prmNodo)
        //{
        //    {
        //        if (prmNodo != null)
        //        {
        //            if (atrSiguiente == null)
        //                atrSiguiente = prmNodo;

        //            else
        //            {
        //                prmNodo.atrSiguiente = atrSiguiente;
        //                atrSiguiente = prmNodo;
        //                //prmNodo.atrAnterior = atrAnterior;
        //                //atrAnterior = prmNodo.atrAnterior;
        //            }
        //            //if (atrAnterior == null)
        //            //    atrAnterior = null;
        //            if (atrAnterior == null)
        //                prmNodo.atrAnterior = this;
        //            else
        //            {
        //                //prmNodo.atrAnterior = atrAnterior;
        //                //atrAnterior = prmNodo;
        //                //atrAnterior = null;
        //                prmNodo.atrAnterior = this;
        //                atrSiguiente.atrAnterior = prmNodo;

        //            }
        //            return true;
        //        }
        //        return false;
        //    }
        //}
        public bool conectar(clsNodoDobleEnlazado<Tipo> prmNodo)
        {
            if (prmNodo != null)
            {
                if (atrSiguiente != null)
                {
                    if (atrAnterior != null)
                    {
                        prmNodo.atrSiguiente = atrSiguiente;
                        atrSiguiente = prmNodo;
                        prmNodo.atrAnterior = this;
                        //atrSiguiente.atrAnterior = prmNodo;
                        return true;
                    }
                }
                prmNodo.atrAnterior = this;
                atrSiguiente = prmNodo;
                return true;
            }
            return false;
        }


        //public bool desconectar(ref clsNodoDobleEnlazado<Tipo> prmNodo)
        //{
        //    if (prmNodo != null)
        //    {
        //        if (atrSiguiente != null)
        //        {
        //            if (atrAnterior != null)
        //            {
        //                prmNodo.atrSiguiente = atrSiguiente;
        //                prmNodo.atrAnterior = atrSiguiente.darAnterior().darAnterior();
        //                return true;
        //            }

        //        }
        //        prmNodo = null;
        //        return true; 
        //    }

        //    return false;
        //}
        //public bool desconectar(ref clsNodoDobleEnlazado<Tipo> prmNodo)
        //{
        //    if (atrSiguiente != null)
        //    {
        //        prmNodo = atrSiguiente;
        //        prmNodo.atrSiguiente = atrSiguiente.atrSiguiente;
        //        prmNodo.atrAnterior = atrAnterior;
        //        //atrAnterior = atrAnterior.atrAnterior;
        //        return true;
        //    }
        //    prmNodo = null;
        //    return false;
        //}
        public bool desconectar(ref clsNodoDobleEnlazado<Tipo> prmNodo)
        {
            if (prmNodo != null)
            {
                if (atrSiguiente != null)
                {
                    if (atrAnterior != null)
                    {
                        prmNodo.atrAnterior = null;
                        atrSiguiente = null;
                    }

                }
                prmNodo.atrAnterior = null;
                atrSiguiente = null;
                return true;
            }
            return false;
        }
        #endregion
    }
}