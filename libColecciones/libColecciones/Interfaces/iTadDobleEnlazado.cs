using Servicios.Colecciones.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicios.Colecciones.Interfaces
{
    public interface iTadDobleEnlazado<Tipo>:iTad<Tipo> where Tipo : IComparable
    {
        clsNodoDobleEnlazado<Tipo> darPrimero();

        clsNodoDobleEnlazado<Tipo> darUltimo();

    }
}
