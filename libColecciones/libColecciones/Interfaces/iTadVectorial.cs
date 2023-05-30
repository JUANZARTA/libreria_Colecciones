using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTadVectorial<Tipo>: iTad<Tipo> where Tipo : IComparable
    {
        #region Accesor
        int darCapacidad();
        Tipo[] darItems();
        #endregion
        #region Mutador
        void poner(Tipo[] prmItem);
        #endregion
        #region ordenamiento
        bool ordenarBurbuja(bool prmPorDescendente);
        bool ordenarCoctel(bool prmOrdenarPorDescendente);
        bool ordenarInsercion(bool prmPorDescendente);
        bool ordenarSeleccion(int[] prmVector);
        bool ordenarMezcla(bool prmPorDescendente);
        bool ordenarQuick(bool prmPorDescendente, int idxInicial, int idxFinal);

        #endregion
        
    }
}
