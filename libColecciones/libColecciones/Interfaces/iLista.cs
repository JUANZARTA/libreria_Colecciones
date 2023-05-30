using System;
namespace Servicios.Colecciones.Interfaces
{
   public interface iLista<Tipo> where Tipo : IComparable
    {
        bool agregar(Tipo prmItem);
        bool insertar(int prmIndice, Tipo prmItem);
        bool remover(int prmIndice,ref Tipo prmItem);
        bool modificar(int prmIndice,  Tipo prmItem);
        bool encontrar(Tipo prmItem, ref int prmIndice);
        bool recuperar(int prmIndice, ref Tipo prmItem);
        
    }
}
