using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Vectoriales;
using System.Linq;

namespace uTestColecciones
{
    [TestClass]
    public class uTestPilaVector
    {
        #region Atributos de prueba
        clsPilaVector<int> atrPilaDatos;
        int atrItem;
        int[] atrTestItems = new int[100];
        #endregion
        #region casos de prueba

        #region Test Constructorparametrizados
        [TestMethod]
        public void uTestConstructorParametrizado()
        {
            #region iniciar
            atrTestItems = new int[4] { 0, 0, 0, 0 };
            atrPilaDatos = new clsPilaVector<int>(4);
            #endregion
            #region probar y comprobar
            Assert.AreEqual(4, atrPilaDatos.darCapacidad());
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(false, ReferenceEquals(null, atrPilaDatos.darItems()));
            #endregion
        }
        #endregion
        #region Test accesores
        [TestMethod]
        public void uTestDarLongitud()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrPilaDatos.poner(new int[4] { 1, 2, 3, 6 });
            #endregion
            #region probar y comprobar

            Assert.AreEqual(4, atrPilaDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void uTestDarCapacidad()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            #endregion
            #region probar y comprobar
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
            #endregion
        }
        [TestMethod]
        public void uTestDarItems()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[100];
            #endregion
            #region probar y comprobar
            Assert.AreEqual(1, atrTestItems.Intersect(atrPilaDatos.darItems()).Count());
            #endregion
        }
        #region Test Mutadores
        [TestMethod]
        public void TestPonerItems()
        {

            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[3] { 1, 2, 3 };
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.poner(new int[3] { 1, 2, 3 });
            Assert.AreEqual(3, atrTestItems.Intersect(atrPilaDatos.darItems()).Count());
            #endregion
        }
        #endregion

        #endregion
        #region Test cruds
        #region TestApilar
        [TestMethod]
        public void uTestApilarItem()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrPilaDatos.apilar(-2000));
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
            Assert.AreEqual(-2000, atrPilaDatos.darItems()[0]);
            #endregion

        }
        [TestMethod]
        public void uTestApilarItems()
        {
            #region iniciar
            atrPilaDatos = new clsPilaVector<int>();


            #endregion
            #region probar y comprobar
            Assert.AreEqual(true, atrPilaDatos.apilar(2000));
            Assert.AreEqual(true, atrPilaDatos.apilar(2001));
            Assert.AreEqual(true, atrPilaDatos.apilar(2002));
            Assert.AreEqual(true, atrPilaDatos.apilar(2003));
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
            Assert.AreEqual(4, atrPilaDatos.darLongitud());
            Assert.AreEqual(2003, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(2002, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(2001, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(2000, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(0, atrPilaDatos.darItems()[4]);

            #endregion
        }
        [TestMethod]
        public void uTestApilarHastaLLenar()
        {
            #region iniciar
            atrItem = 0;
            atrPilaDatos = new clsPilaVector<int>(5);
            atrPilaDatos.poner(new int[] { 1, 2, 3, 4, 5 });

            #endregion
            #region Test probar y comprobar
            Assert.AreEqual(false, atrPilaDatos.apilar(6));
            Assert.AreEqual(5, atrPilaDatos.darLongitud());
            Assert.AreEqual(1, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[atrPilaDatos.darLongitud() - 1]);
            Assert.AreEqual(4, atrPilaDatos.darCapacidad() - 1);
            #endregion
        }
        #endregion
        #region Test Desapilar
        [TestMethod]
        public void uTestDesapilarItem()
        {
            #region iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrPilaDatos.poner(new int[4] { 112, 789, 456, 123 });
            atrItem = 0;
            #endregion
            #region probar y comprobar
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref atrItem));
            Assert.AreEqual(112, atrItem);
            Assert.AreEqual(789, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(3, atrPilaDatos.darLongitud());
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref atrItem));
            Assert.AreEqual(789, atrItem);
            Assert.AreEqual(2, atrPilaDatos.darLongitud());
            Assert.AreEqual(456, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(123, atrPilaDatos.darItems()[atrPilaDatos.darLongitud() - 1]);
            Assert.AreEqual(100, atrPilaDatos.darCapacidad());
            Assert.AreEqual(false, ReferenceEquals(null, atrPilaDatos.darItems()));


            #endregion

        }
        [TestMethod]
        public void Desapilarhastavaciar()
        {

            #region iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrPilaDatos.poner(new int[2] { 1, 2 });
            #endregion
            #region probar y comprobar
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref atrItem));
            Assert.AreEqual(1, atrItem);
            Assert.AreEqual(1, atrPilaDatos.darLongitud());
            Assert.AreEqual(true, atrPilaDatos.desapilar(ref atrItem));
            Assert.AreEqual(2, atrItem);
            Assert.AreEqual(0, atrPilaDatos.darLongitud());
            Assert.AreEqual(false, atrPilaDatos.desapilar(ref atrItem));
            #endregion
        }
        #endregion
        #region test revisar
        [TestMethod]
        public void Revisar()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[3] { 1, 2, 3 };
            atrPilaDatos.poner(atrTestItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrPilaDatos.revisar(ref atrItem));
            Assert.AreEqual(1, atrItem);
            #endregion
            #region Provisinal
            Servicios.Colecciones.Nodos.clsNodoDobleEnlazado<int> varNodos = new Servicios.Colecciones.Nodos.clsNodoDobleEnlazado<int>();
            #endregion
        }
        #endregion
        #endregion

        #region Test Ordenamiento
        #region Test Burbuja
        [TestMethod]
        public void uTestOrdenarBurbujaDescendente()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarBurbuja(true);
            Assert.AreEqual(9, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(1, atrPilaDatos.darItems()[9]);
            Assert.AreEqual(true, atrPilaDatos.darEstaOrdenadoDescendente());
            Assert.AreEqual(false, atrPilaDatos.darEstaOrdenadoAscendente());
            #endregion
        }
        [TestMethod]
        public void uTestOrdenarBurbujaAscendente()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarBurbuja(false);
            Assert.AreEqual(1, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(9, atrPilaDatos.darItems()[9]);
            #endregion
        }
        #endregion
        #region Test Seleccion
        [TestMethod]
        public void uTestOrdenarSeleccionDescendente()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarSeleccion(true);
            Assert.AreEqual(9, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(1, atrPilaDatos.darItems()[9]);
            Assert.AreEqual(true, atrPilaDatos.darEstaOrdenadoDescendente());
            Assert.AreEqual(false, atrPilaDatos.darEstaOrdenadoAscendente());
            #endregion
        }
        [TestMethod]
        public void uTestOrdenarSeleccionAscendente()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarSeleccion(false);
            Assert.AreEqual(1, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(9, atrPilaDatos.darItems()[9]);
            Assert.AreEqual(false, atrPilaDatos.darEstaOrdenadoDescendente());
            Assert.AreEqual(true, atrPilaDatos.darEstaOrdenadoAscendente());
            #endregion
        }
        #endregion
        #region Test Insercion
        [TestMethod]
        public void uTestOrdenarInsercionDescendente()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarInsercion(true);
            Assert.AreEqual(9, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(1, atrPilaDatos.darItems()[9]);
            Assert.AreEqual(true, atrPilaDatos.darEstaOrdenadoDescendente());
            Assert.AreEqual(false, atrPilaDatos.darEstaOrdenadoAscendente());
            #endregion
        }
        [TestMethod]
        public void uTestOrdenarInsercionAscendente()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarInsercion(false);
            Assert.AreEqual(1, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(9, atrPilaDatos.darItems()[9]);
            Assert.AreEqual(false, atrPilaDatos.darEstaOrdenadoDescendente());
            Assert.AreEqual(true, atrPilaDatos.darEstaOrdenadoAscendente());
            #endregion
        }
        #endregion
        #region Test Mezcla
        [TestMethod]
        public void uTestOrdenarMezclaDescendente()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarMezcla(true, 0, 9);
            Assert.AreEqual(9, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(1, atrPilaDatos.darItems()[9]);
            Assert.AreEqual(true, atrPilaDatos.darEstaOrdenadoDescendente());
            Assert.AreEqual(false, atrPilaDatos.darEstaOrdenadoAscendente());
            #endregion
        }
        #endregion
        #region Test Coctel
        [TestMethod]
        public void uTestOrdenarCoctel()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarCoctel(true);
            Assert.AreEqual(9, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(1, atrPilaDatos.darItems()[9]);
            atrPilaDatos.ordenarBurbuja(false);
            Assert.AreEqual(1, atrPilaDatos.darItems()[0]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[1]);
            Assert.AreEqual(2, atrPilaDatos.darItems()[2]);
            Assert.AreEqual(3, atrPilaDatos.darItems()[3]);
            Assert.AreEqual(4, atrPilaDatos.darItems()[4]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[5]);
            Assert.AreEqual(5, atrPilaDatos.darItems()[6]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[7]);
            Assert.AreEqual(8, atrPilaDatos.darItems()[8]);
            Assert.AreEqual(9, atrPilaDatos.darItems()[9]);
            #endregion
        }
        #endregion
        #region Test Quick
        [TestMethod]
        public void uTestOrdenarQuick()
        {
            #region Iniciar
            atrPilaDatos = new clsPilaVector<int>();
            atrTestItems = new int[10] { 5, 2, 4, 8, 3, 5, 1, 2, 8, 9 };
            atrPilaDatos.poner(atrTestItems);
            atrItem = 0;
            #endregion
            #region Probar y Comprobar
            atrPilaDatos.ordenarQuick(true, 0, 9);
            Assert.AreEqual(9, atrPilaDatos.darItems()[0]);
            #endregion
        }
        #endregion
        #endregion

        #endregion

    }
}
