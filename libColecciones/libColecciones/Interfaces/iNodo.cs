using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
   public interface iNodo<Tipo> where Tipo : IComparable
    {
        #region Accesores
        Tipo darItem();// darItem O daritems??
        #endregion
        #region Mutadores
        void poner(Tipo prmItem );
        #endregion
    }
}
