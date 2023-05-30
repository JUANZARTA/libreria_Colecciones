using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTadSimpleEnlazado<Tipo>: iTad<Tipo> where Tipo:IComparable
    {
        #region Accesor
        clsNodoSimpleEnlazado<Tipo> darPrimero();
        clsNodoSimpleEnlazado<Tipo> darUltimo();
        #endregion
    }
}
