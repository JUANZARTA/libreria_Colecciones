using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Vectoriales;
using System.Linq;

namespace uTestColecciones
{
    [TestClass]
    public class uTestColaVector
    {
        #region Atributos de prueba
        clsColaVector<int> atrColaDatos;
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
            atrColaDatos = new clsColaVector<int>(4);
            #endregion
            #region probar y comprobar
            Assert.AreEqual(4, atrColaDatos.darCapacidad());
            Assert.AreEqual(0, atrColaDatos.darLongitud());
            Assert.AreEqual(false, ReferenceEquals(null, atrColaDatos.darItems()));
            #endregion
        }
        #endregion
        #region Test accesores

        [TestMethod]
        public void uTestDarCapacidad()
        {
            #region Iniciar
            atrColaDatos = new clsColaVector<int>();
            atrColaDatos.poner(new int[3] { 1, 2, 3 });
            #endregion
            #region probar y comprobar

            Assert.AreEqual(100, atrColaDatos.darCapacidad());
            #endregion
        }
        [TestMethod]
        public void uTestDarLongitud()
        {
            #region Iniciar
            atrColaDatos = new clsColaVector<int>();
            atrColaDatos.poner(new int[3] { 1, 2, 3 });
            #endregion
            #region probar y comprobar
            Assert.AreEqual(3, atrColaDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void uTestDarItems()
        {
            #region Iniciar
            atrColaDatos = new clsColaVector<int>();
            atrTestItems = new int[100];
            #endregion
            #region probar y comprobar
            Assert.AreEqual(1, atrTestItems.Intersect(atrColaDatos.darItems()).Count());
            #endregion
        }

        #region Test Mutadores
        [TestMethod]
        public void TestPonerItems()
        {

            #region Iniciar
            atrColaDatos = new clsColaVector<int>();
            atrTestItems = new int[3] { 1, 2, 3 };
            #endregion
            #region Probar y Comprobar
            atrColaDatos.poner(new int[3] { 1, 2, 3 });
            Assert.AreEqual(3, atrTestItems.Intersect(atrColaDatos.darItems()).Count());
            #endregion
        }
        #endregion

        #endregion
        #region Test Cruds
        #region TestEncolar
        [TestMethod]
        public void uTestEncolarItem()
        {
            #region Iniciar
            atrColaDatos = new clsColaVector<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrColaDatos.encolar(2000));
            Assert.AreEqual(100, atrColaDatos.darCapacidad());
            Assert.AreEqual(1, atrColaDatos.darLongitud());
            Assert.AreEqual(2000, atrColaDatos.darItems()[0]);
            #endregion

        }
        [TestMethod]
        public void uTestEncolarItems()
        {
            #region iniciar
            atrColaDatos = new clsColaVector<int>();

            #endregion
            #region probar y comprobar
            Assert.AreEqual(true, atrColaDatos.encolar(2000));
            Assert.AreEqual(true, atrColaDatos.encolar(2001));
            Assert.AreEqual(true, atrColaDatos.encolar(2002));
            Assert.AreEqual(true,atrColaDatos.encolar(2003));
            Assert.AreEqual(100, atrColaDatos.darCapacidad());
            Assert.AreEqual(4, atrColaDatos.darLongitud());
            Assert.AreEqual(2000, atrColaDatos.darItems()[0]);
            Assert.AreEqual(2001, atrColaDatos.darItems()[1]);
            Assert.AreEqual(2002, atrColaDatos.darItems()[2]);
            Assert.AreEqual(2003, atrColaDatos.darItems()[3]);
            Assert.AreEqual(0, atrColaDatos.darItems()[4]);
            #endregion
        }
        [TestMethod]
        public void uTestEncolarHastaLLenar()
        {
            #region iniciar
            atrItem = 0;
            atrColaDatos = new clsColaVector<int>(5);
            atrColaDatos.poner(new int[] { 1, 2, 3, 4, 5 });

            #endregion
            #region Test probar y comprobar
            Assert.AreEqual(false, atrColaDatos.encolar(6));
            Console.Write("limite alcanzado");
            Assert.AreEqual(5, atrColaDatos.darLongitud());
            Assert.AreEqual(1, atrColaDatos.darItems()[0]);
            Assert.AreEqual(3, atrColaDatos.darItems()[2]);
            Assert.AreEqual(5, atrColaDatos.darItems()[atrColaDatos.darLongitud() - 1]);
            Assert.AreEqual(4, atrColaDatos.darCapacidad() - 1);
            #endregion
        }
        #endregion
        #region Test Desencolar
        [TestMethod]
        public void uTestDesencolarItem()
        {
            #region iniciar
            atrColaDatos = new clsColaVector<int>();
            atrColaDatos.poner(new int[] { 012,789,456,125});
            atrItem = 0;
            #endregion
            #region probar y comprobar
            Assert.AreEqual(true, atrColaDatos.desencolar(ref atrItem));
            Assert.AreEqual(012, atrItem);
            Assert.AreEqual(3, atrColaDatos.darLongitud());
            Assert.AreEqual(789,atrColaDatos.darItems()[0]);
            Assert.AreEqual(true, atrColaDatos.desencolar(ref atrItem));
            Assert.AreEqual(789, atrItem);
            Assert.AreEqual(2, atrColaDatos.darLongitud());
            Assert.AreEqual(456, atrColaDatos.darItems()[0]);
            Assert.AreEqual(125, atrColaDatos.darItems()[atrColaDatos.darLongitud() - 1]);
            Assert.AreEqual(100, atrColaDatos.darCapacidad());
            #endregion
        }
        [TestMethod]
        public void uTestDesencolarHastaVaciar()
        {
            #region Iniciar
            atrColaDatos = new clsColaVector<int>();
            atrColaDatos.poner(new int[2] { 1,2});
            #endregion
            #region probar y comprobar}
            Assert.AreEqual(true,atrColaDatos.desencolar(ref atrItem));
            Assert.AreEqual(1,atrColaDatos.darLongitud());
            Assert.AreEqual(1,atrItem);
            Assert.AreEqual(2,atrColaDatos.darItems()[0]);
            Assert.AreEqual(true,atrColaDatos.desencolar(ref atrItem));
            Assert.AreEqual(0,atrColaDatos.darLongitud());
            Assert.AreEqual(2,atrItem);
            //Assert.AreEqual(0,atrColaDatos.darItems()[0]);
            Assert.AreEqual(100,atrColaDatos.darCapacidad());
            #endregion
        }
        #endregion
        #region test revisar
        [TestMethod]
        public void Revisar()
        {
            #region Iniciar
            atrColaDatos = new clsColaVector<int>();
            atrTestItems = new int[3] { 1, 2, 3 };
            atrColaDatos.poner(atrTestItems);
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrColaDatos.revisar(ref atrItem));
            Assert.AreEqual(1, atrItem);

            #endregion
        }
        #endregion
        #endregion
        #region Test Metodos de ordenamiento
        [TestMethod]
        public void TestOrdenarPorSeleccion()
        {
            #region Iniciar
            atrColaDatos = new clsColaVector<int>();
            atrColaDatos.poner(new int[] { 8, 3, 4, 5, 5, 82, 10 });
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrColaDatos.ordenarSeleccion(atrColaDatos.darItems()));
            Assert.AreEqual(7, atrColaDatos.darLongitud());
            Assert.AreEqual(3, atrColaDatos.darItems()[0]);
            Assert.AreEqual(4, atrColaDatos.darItems()[1]);
            Assert.AreEqual(5, atrColaDatos.darItems()[2]);
            Assert.AreEqual(5, atrColaDatos.darItems()[3]);
            Assert.AreEqual(8, atrColaDatos.darItems()[4]);
            Assert.AreEqual(10, atrColaDatos.darItems()[5]);
            Assert.AreEqual(82, atrColaDatos.darItems()[6]);
            #endregion
        }
        #endregion
        #endregion
    }
}
