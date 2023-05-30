using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : clsTadVectorial<Tipo>, iPila<Tipo> where Tipo : IComparable
    {
        #region Atributos
        #region Propios
        //ubicacion: clsTadVectorial
        #endregion
        #endregion
        #region Metodos
        #region Costructores
        public clsPilaVector()
        {
        }
        public clsPilaVector(int prmCapacidad) : base(prmCapacidad)
        {

        }
        #endregion              
        #region CRUDS
        public bool apilar(Tipo prmItem)
        {
            if (atrLongitud < atrCapacidad)
            {
                Desplazar();
                atrItems[0] = prmItem;
                atrLongitud++;
                return true;
            }
            return false;
        }
        public bool desapilar(ref Tipo prmItem)
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            else
            {
                prmItem = atrItems[0];
                eliminar_ult();
                atrLongitud--;
            }
            return true;
        }
        public bool revisar(ref Tipo prmItem)
        {
            for (int i = 0; i <= atrLongitud; i++)
            {
                prmItem = atrItems[i];

                return true;
            }
            return false;
        }
        #endregion     
        #endregion
        #region Complementos   
        public bool Desplazar()

        {
            for (int i = atrLongitud; i > 0; i--)
                atrItems[i] = atrItems[i - 1];

            return true;

        }
        public bool eliminar_ult()
        {
            for (int i = 1; i < atrLongitud; i++)
                atrItems[i - 1] = atrItems[i];
            return true;
        }
        #endregion

        #region Metodos de ordenamiento
        private bool IncrementarComparaciones()
        {
            atrComparaciones += 1;
            return true;
        }
        public bool ordenarBurbuja(bool prmOrdenarPorDescendente)
        {
            int varPosExterior = default(int), varPosInterior = default(int), varComparacion = default(int);
            Tipo varElementoTemporal;
            for (varPosExterior = 1; varPosExterior < atrLongitud; varPosExterior++)
            {
                for (varPosInterior = 0; varPosInterior < (atrLongitud - (varPosExterior)); varPosInterior++)
                {
                    atrComparaciones = atrComparaciones + 1;
                    varComparacion = atrItems[varPosInterior].CompareTo(atrItems[varPosInterior + 1]);
                    if (varComparacion != 0 && (prmOrdenarPorDescendente ^ varComparacion > 0))
                    {
                        varElementoTemporal = atrItems[varPosInterior];
                        atrItems[varPosInterior] = atrItems[varPosInterior + 1];
                        atrItems[varPosInterior + 1] = varElementoTemporal;
                        atrIntercambios = atrIntercambios + 1;
                    }
                }
            }
            return true;
        }
        public bool ordenarCoctel(bool prmPorDescendente)
        {
            if (prmPorDescendente)
                for (int varContador0 = 1; varContador0 <= atrLongitud - 1; varContador0++)
                {
                    for (int varContador1 = 0; varContador1 <= atrLongitud - varContador0 - 1; varContador1++)
                    {
                        atrComparaciones++;
                        if (atrItems[varContador1].CompareTo(atrItems[varContador1 + 1]) <= 0)
                        {
                            atrIntercambios++;

                            Tipo varAux = atrItems[varContador1];
                            atrItems[varContador1] = atrItems[varContador1 + 1];
                            atrItems[varContador1 + 1] = varAux;
                        }
                    }
                }
            else
                for (int varContador0 = 1; varContador0 <= atrLongitud - 1; varContador0++)
                {
                    for (int varContador1 = 0; varContador1 <= atrLongitud - varContador0 - 1; varContador1++)
                    {
                        atrComparaciones++;
                        if (atrItems[varContador1].CompareTo(atrItems[varContador1 + 1]) > 0)
                        {
                            atrIntercambios++;

                            Tipo varAux = atrItems[varContador1];
                            atrItems[varContador1] = atrItems[varContador1 + 1];
                            atrItems[varContador1 + 1] = varAux;
                        }
                    }
                }
            return true;
        }
        public bool ordenarSeleccion(bool prmPorDescendente)
        {
            try
            {
                int varPosExterior, varPosInterior, varPosDelMinimo;
                Tipo varElementoTemporal;

                for (varPosExterior = 0; varPosExterior < atrLongitud - 1; varPosExterior++)
                {
                    varPosDelMinimo = varPosExterior;
                    for (varPosInterior = varPosExterior + 1; varPosInterior < atrLongitud; varPosInterior++)
                    {
                        atrComparaciones++;
                        if (prmPorDescendente ^ atrItems[varPosDelMinimo].CompareTo(atrItems[varPosInterior]) > 0)
                        {
                            varPosDelMinimo = varPosInterior;
                        }
                    }
                    if (varPosDelMinimo != varPosExterior)
                    {
                        varElementoTemporal = atrItems[varPosDelMinimo];
                        atrItems[varPosDelMinimo] = atrItems[varPosExterior];
                        atrItems[varPosExterior] = varElementoTemporal;
                        atrIntercambios++;
                    }
                }
                if (prmPorDescendente) atrEstaOrdenadoDescendente = true;
                if (!prmPorDescendente) atrEstaOrdenadoAscendente = true;
                if (atrLongitud == 0)
                {
                    atrEstaOrdenadoAscendente = false;
                    atrEstaOrdenadoDescendente = false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ordenarInsercion(bool prmPorDescendente)
        {
            int varIterador, varIndiceAnterior, varIndiceSiguiente;

            Tipo varAux;
            if (atrLongitud > 1)
            {
                if (prmPorDescendente == false)
                {
                    for (varIterador = 1; varIterador < atrLongitud; varIterador++)
                    {
                        varAux = atrItems[varIterador];
                        varIndiceAnterior = varIterador - 1;
                        while ((IncrementarComparaciones()) && (varIndiceAnterior >= 0) && (varAux.CompareTo(atrItems[varIndiceAnterior]) < 0))
                        {
                            atrItems[varIndiceAnterior + 1] = atrItems[varIndiceAnterior];
                            varIndiceAnterior--;

                        }
                        atrItems[varIndiceAnterior + 1] = varAux;
                        atrInserciones++;
                    }
                    return true;

                }
                else
                {
                    for (varIterador = 1; varIterador < atrLongitud; varIterador++)
                    {
                        varAux = atrItems[varIterador];
                        varIndiceSiguiente = varIterador - 1;
                        while ((IncrementarComparaciones()) && (varIndiceSiguiente >= 0) && (varAux.CompareTo(atrItems[varIndiceSiguiente]) > 0))
                        {
                            atrItems[varIndiceSiguiente + 1] = atrItems[varIndiceSiguiente];
                            varIndiceSiguiente--;
                        }
                        atrItems[varIndiceSiguiente + 1] = varAux;
                        atrInserciones++;
                    }
                    return true;

                }

            }
            return false;
        }
        public bool ordenarMezcla(bool prmPorDescendente, int prmIdxInicial, int prmIdxFinal)
        {
            poner(mergeSort(atrItems));
            return true;
        }
        public bool ordenarQuick(bool prmPorDescendente, int prmIdxInicial, int prmIdxFinal)
        {
            int izquierda, derecha;
            Tipo pivote, auxiliar;
            pivote = atrItems[(prmIdxInicial + prmIdxFinal) / 2];
            izquierda = prmIdxInicial;
            derecha = prmIdxFinal;

            do
            {
                if (prmPorDescendente == true)
                {
                    atrComparaciones++;
                    while (atrItems[izquierda].CompareTo(pivote) > 0)
                    {
                        izquierda++;
                        atrComparaciones++;
                    }
                    while (atrItems[derecha].CompareTo(pivote) < 0)
                    {
                        derecha--;
                        atrComparaciones++;
                    }
                }
                else
                {
                    while (atrItems[izquierda].CompareTo(pivote) < 0)
                    {
                        izquierda++;
                        atrComparaciones++;
                    }
                    while (atrItems[derecha].CompareTo(pivote) > 0)
                    {
                        derecha--;
                        atrComparaciones++;
                    }
                }
                if (izquierda <= derecha)
                {
                    auxiliar = atrItems[izquierda];
                    atrItems[izquierda] = atrItems[derecha];
                    atrItems[derecha] = auxiliar;
                    izquierda++;
                    derecha--;
                    atrIntercambios++;
                }
            } while (izquierda <= derecha);

            if (prmIdxInicial < derecha)
            {
                ordenarQuick(prmPorDescendente, prmIdxInicial, derecha);
                atrRecursiones++;
            }
            if (izquierda < prmIdxFinal)
            {
                ordenarQuick(prmPorDescendente, izquierda, prmIdxFinal);
                atrRecursiones++;
            }
            return true;
        }

        #region MergeSort
        public Tipo[] mergeSort(Tipo[] prmVector)
        {
            //iniciar
            int longitud = prmVector.Length;
            if (longitud < 2)
            {
                return prmVector;
            }
            // iniciar separacion
            int indice = 0;
            int mitad = longitud / 2;
            Tipo[] mitadIzquierda;
            Tipo[] mitadDerecha;
            // insertar los items en la separacion
            if (longitud % 2 == 0)
            {
                mitadIzquierda = new Tipo[longitud / 2];
                mitadDerecha = new Tipo[longitud / 2];
            }
            else
            {
                mitadIzquierda = new Tipo[longitud / 2];
                mitadDerecha = new Tipo[(longitud / 2) + 1];
            }
            //repartir mitades
            if (longitud % 2 == 0)
            {
                for (int i = 0; i < mitad; i++)
                {
                    mitadIzquierda[i] = prmVector[indice];
                    indice++;
                }
                for (int i = 0; i < mitad; i++)
                {
                    mitadDerecha[i] = prmVector[indice];
                    indice++;
                }
            }
            else
            {
                for (int i = 0; i < mitad; i++)
                {
                    mitadIzquierda[i] = prmVector[indice];
                    indice++;
                }
                for (int i = 0; i < mitad + 1; i++)
                {
                    mitadDerecha[i] = prmVector[indice];
                    indice++;
                }
            }
            // Organizar mitades
            mitadIzquierda = mergeSort(mitadIzquierda);
            mitadDerecha = mergeSort(mitadDerecha);
            Tipo[] listaOrdenada = merge(mitadIzquierda, mitadDerecha);
            // retornar lista ordenada
            return listaOrdenada;
        }
        #endregion
        #region Merge
        public Tipo[] merge(Tipo[] atrListaIzquierda, Tipo[] atrListaDerecha)
        {
            //iniciar
            Tipo[] VectorOrdenado = new Tipo[atrListaIzquierda.Length + atrListaDerecha.Length];
            int indiceIzquierdo = 0;
            int indiceDerecho = 0;
            int Indice = 0;
            int cantidadIzquierda = atrListaIzquierda.Length;
            int cantidadDerecha = atrListaDerecha.Length;
            //insertar los items en una lista ordenada
            while ((indiceIzquierdo < cantidadIzquierda) && (indiceDerecho < cantidadDerecha))
            {
                if (atrListaIzquierda[indiceIzquierdo].CompareTo(atrListaDerecha[indiceDerecho]) <= 0)
                {
                    VectorOrdenado[Indice] = atrListaIzquierda[indiceIzquierdo];
                    indiceIzquierdo++;
                    Indice++;

                }
                else
                {
                    VectorOrdenado[Indice] = atrListaDerecha[indiceDerecho];
                    indiceDerecho++;
                    Indice++;
                }
            }
            //insertar elementos restantes
            while (indiceIzquierdo < cantidadIzquierda)
            {
                VectorOrdenado[Indice] = atrListaIzquierda[indiceIzquierdo];
                indiceIzquierdo++;
                Indice++;
            }
            while (indiceDerecho < cantidadDerecha)
            {
                VectorOrdenado[Indice] = atrListaDerecha[indiceDerecho];
                indiceDerecho++;
                Indice++;
            }
            //retornar lista ordenada
            return VectorOrdenado;
        }
        #endregion
        #endregion

    }

}