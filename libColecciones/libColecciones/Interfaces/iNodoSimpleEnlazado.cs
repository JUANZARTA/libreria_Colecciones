using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Interfaces
{
    public interface iNodoSimpleEnlazado<Tipo> : iNodo<Tipo> where Tipo : IComparable
    {
        clsNodoSimpleEnlazado<Tipo> darSiguiente();
        bool conectar(clsNodoSimpleEnlazado<Tipo> prmNodo);
        bool desconectar(ref clsNodoSimpleEnlazado<Tipo> prmNodo);
    }


}
