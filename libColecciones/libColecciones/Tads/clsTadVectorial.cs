using Servicios.Colecciones.Interfaces;
using System;
using System.Diagnostics;

namespace Servicios.Colecciones.Tads
{
    public class clsTadVectorial<Tipo> : clsTad<Tipo>, iTadVectorial<Tipo> where Tipo : IComparable
    {
        #region Atributos
        protected int atrCapacidad;
        protected Tipo[] atrItems;
        protected bool atrEstaOrdenadoAscendente;
        protected bool atrEstaOrdenadoDescendente;
        protected int atrComparaciones;
        protected int atrIntercambios;
        protected int atrInserciones;
        protected int atrRecursiones;
        #endregion
        #region Constructor
        protected clsTadVectorial()
        {
            atrCapacidad = 100;
            atrItems = new Tipo[atrCapacidad];
        }
        protected clsTadVectorial(int prmCapacidad)
        {
            try
            {
                atrCapacidad = prmCapacidad;
                atrItems = new Tipo[prmCapacidad];
            }
            catch (System.Exception)
            {
                atrCapacidad = 100;
                atrItems = new Tipo[atrCapacidad];
            }

        }
        #endregion
        #region Accesores
        public int darCapacidad()
        {
            return atrCapacidad;
        }
        public Tipo[] darItems()
        {
            return atrItems;
        }
        public bool darEstaOrdenadoAscendente()
        {
            return atrEstaOrdenadoAscendente;
        }
        public bool darEstaOrdenadoDescendente()
        {
            return atrEstaOrdenadoDescendente;
        }
        #endregion    
        #region Mutadores
        public void poner(Tipo[] prmItems)
        {
            atrItems = prmItems;
            atrLongitud = atrItems.Length;
        }
        #endregion
        #region ordenamiento
        private bool IncrementarComparaciones()
        {
            atrComparaciones += 1;
            return true;
        }
        public bool ordenarBurbuja(bool prmPorDescendente)
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
        public bool ordenarCoctel(bool prmOrdenarPorDescendente)
        {
            bool varIntercambios;
            int varPosicion, varComparacion;
            Tipo varItemTemporal;
            do
            {
                varIntercambios = false;
                for (varPosicion = 0; varPosicion < atrLongitud; varPosicion++)
                {
                    atrComparaciones = atrComparaciones + 1;
                    varComparacion = atrItems[varPosicion].CompareTo(atrItems[varPosicion + 1]);
                    if (varComparacion != 0 && (prmOrdenarPorDescendente ^ varComparacion > 0))
                    {
                        varItemTemporal = atrItems[varPosicion];
                        atrItems[varPosicion] = atrItems[varPosicion + 1];
                        atrItems[varPosicion + 1] = varItemTemporal;
                        varIntercambios = true;
                        atrIntercambios = atrIntercambios + 1;
                    }
                }
                if (varIntercambios == false)
                {
                    break;
                }
                varIntercambios = false;
                for (varPosicion = atrLongitud; varPosicion < 0; varPosicion = varPosicion - 1)
                {
                    atrComparaciones = atrComparaciones + 1;
                    varComparacion = atrItems[varPosicion].CompareTo(atrItems[varPosicion + 1]);
                    if (varComparacion != 0 && (prmOrdenarPorDescendente ^ varComparacion > 0))
                    {
                        varItemTemporal = atrItems[varPosicion];
                        atrItems[varPosicion] = atrItems[varPosicion + 1];
                        atrItems[varPosicion + 1] = varItemTemporal;
                        varIntercambios = true;
                        atrIntercambios = atrIntercambios + 1;
                    }
                }
            } while (varIntercambios == true);
            return true;
        }
        public bool ordenarInsercion(bool prmPorDescendente)
        {
            int varIterador, varIndiceAnterior, varIndiceSiguiente;
            Stopwatch atrTiempoEjecucion = new Stopwatch();

            Tipo varAux;
            atrTiempoEjecucion.Start();
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
                    atrTiempoEjecucion.Stop();
                    //ValorTiempoEjecucion = atrTiempoEjecucion.Elapsed.TotalSeconds;
                    //ValorTiempoEjecucionTicks = atrTiempoEjecucion.ElapsedTicks;
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
                    atrTiempoEjecucion.Stop();
                    //ValorTiempoEjecucion = atrTiempoEjecucion.Elapsed.TotalSeconds;
                    //ValorTiempoEjecucionTicks = atrTiempoEjecucion.ElapsedTicks;
                    return true;

                }

            }
            atrTiempoEjecucion.Stop();
            return false;
        }
        public bool ordenarSeleccion(int[] prmVector)
        {
            int tamanioVector = prmVector.Length;
            int minimo = 0;
            int aux = 0;
            for (int i = 0; i < tamanioVector - 1; i++)
            {
                minimo = i;
                for (int j = i + 1; j < tamanioVector; j++)
                {
                    if (prmVector[j] < prmVector[minimo])
                    {
                        minimo = j;
                    }
                }
                aux = prmVector[i];
                prmVector[i] = prmVector[minimo];
                prmVector[minimo] = aux;
            }
            return true;
        }
        #region Mezcla
        public bool ordenarMezcla(bool prmPorDescendente)
        {
            poner(mergeSort(atrItems));
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
        public bool ordenarQuick(bool prmPorDescendente, int idxInicial, int idxFinal)
        {
            int izquierda, derecha;
            Tipo pivote, auxiliar;
            pivote = atrItems[(idxInicial + idxFinal) / 2];
            izquierda = idxInicial;
            derecha = idxFinal;

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
                    atrComparaciones++;
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

            if (idxInicial < derecha)
            {
                ordenarQuick(prmPorDescendente, idxInicial, derecha);
                atrRecursiones++;
            }
            if (izquierda < idxFinal)
            {
                ordenarQuick(prmPorDescendente, izquierda, idxFinal);
                atrRecursiones++;
            }
            return true;
        }
        #endregion


    }
}
