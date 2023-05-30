 using Servicios.Colecciones.Interfaces;
using System;


namespace Servicios.Colecciones.Tads
{
    public class clsTad<Tipo>:iTad<Tipo> where Tipo: IComparable
    {
        #region Atributos
        protected int atrLongitud;
        #endregion
        #region Operaciones
        public int darLongitud()
        {
            return atrLongitud;
        }
        #endregion
        #region Interface Itad Iterador
        public int darIndiceActual()
        {
            throw new NotImplementedException();
        }

        public Tipo darItemActual()
        {
            throw new NotImplementedException();
        }

        public void poneritemActual()
        {
            throw new NotImplementedException();
        }

        public bool irPrimero()
        {
            throw new NotImplementedException();
        }

        public bool irUltimo()
        {
            throw new NotImplementedException();
        }

        public bool irAnterior()
        {
            if (existeAnterior())
            {
                return true;
            }
            return false;
        }

        public bool irSiguiente()
        {
            throw new NotImplementedException();
        }

        public bool IrIndice(int prmIndice)
        {
            throw new NotImplementedException();
        }

        public bool avanzar()
        {
            throw new NotImplementedException();
        }

        public bool retroceder()
        {
            throw new NotImplementedException();
        }

        public bool existeSiguiente()
        {
            throw new NotImplementedException();
        }

        public bool existeAnterior()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
