using Servicios.Colecciones.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface iNodoDobleEnlazado<Tipo> : iNodo<Tipo> where Tipo : IComparable
    {
        clsNodoDobleEnlazado<Tipo> darAnterior();

        clsNodoDobleEnlazado<Tipo> darSiguiente();
        bool conectar(clsNodoDobleEnlazado<Tipo> prmNodo);
        bool desconectar(ref clsNodoDobleEnlazado<Tipo> prmNodo);
    }
}
