using System;
namespace Servicios.Colecciones.Interfaces
{
    public interface iTad<Tipo> where Tipo: IComparable
    {
        #region Accesores
        int darLongitud();
        #endregion
        #region Iterador-Accesor
        int darIndiceActual();
        Tipo darItemActual();
        #endregion
        #region Iterador-Mutador
        void poneritemActual();
        #endregion
        #region Iterador-Poscicionador
        bool irPrimero();
        bool irUltimo();
        bool irAnterior();
        bool irSiguiente();
        bool IrIndice(int prmIndice);
        bool avanzar();
        bool retroceder();
        #endregion
        #region Iterador-Consultor
        bool existeSiguiente();
        bool existeAnterior();
        #endregion
    }
}
