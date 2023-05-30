using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.SimpleEnlazadas;

namespace uTestColecciones
{
    [TestClass]
    public class uTestColaSimpleEnlazada
    {
        #region atributos de prueba
        clsColaSimpleEnlazada<int> atrColaSimpleDatos;
        int[] atrTestItems = new int[100];
        #endregion

        #region casos de pureba encolar
        [TestMethod]
        public void uTestEncolarunItem()
        {
            #region iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrColaSimpleDatos.encolar(2000));
            Assert.AreEqual(2000, atrColaSimpleDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrColaSimpleDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrColaSimpleDatos.darLongitud());
            #endregion

        }
        [TestMethod]
        public void uTestEncolarDosItem()
        {
            #region iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrColaSimpleDatos.encolar(999));
            Assert.AreEqual(true, atrColaSimpleDatos.encolar(500));
            Assert.AreEqual(2, atrColaSimpleDatos.darLongitud());
            Assert.AreEqual(999, atrColaSimpleDatos.darPrimero().darItem());  
            Assert.AreEqual(500, atrColaSimpleDatos.darUltimo().darItem());

            #endregion
        }
        [TestMethod]
        public void uTestEncolarVariosItem()
        {
            #region Iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrColaSimpleDatos.encolar(999));
            Assert.AreEqual(true, atrColaSimpleDatos.encolar(500));
            Assert.AreEqual(true, atrColaSimpleDatos.encolar(300));
            Assert.AreEqual(3, atrColaSimpleDatos.darLongitud());
            Assert.AreEqual(999, atrColaSimpleDatos.darPrimero().darItem());  // dar nodoprimero o dar primero
            Assert.AreEqual(300, atrColaSimpleDatos.darUltimo().darItem());

            #endregion

        }
        #endregion       
        #region casos de prueba Desencolar
        [TestMethod]
        public void uTestDesencolarConColaVacia()
        {
            #region iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaSimpleDatos.desencolar(ref varElementoDesencolado);
            Assert.AreEqual(false, varResultadoDesencolar);
            Assert.AreEqual(0, varElementoDesencolado);
            Assert.AreEqual(0, atrColaSimpleDatos.darLongitud());
            Assert.AreEqual(null, atrColaSimpleDatos.darPrimero());
            Assert.AreEqual(null, atrColaSimpleDatos.darUltimo());

            #endregion

        }
        [TestMethod]
        public void uTestDesencolarUnItemCaso1()
        {
            #region Iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            atrColaSimpleDatos.encolar( 2000);
            atrColaSimpleDatos.encolar( 5000);
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaSimpleDatos.desencolar(ref varElementoDesencolado);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(1, atrColaSimpleDatos.darLongitud());
            Assert.AreEqual(5000, atrColaSimpleDatos.darPrimero().darItem());
            Assert.AreEqual(5000, atrColaSimpleDatos.darUltimo().darItem());

            #endregion

        }
        [TestMethod]
        public void uTestDesencolarUnItemCaso2()
        {
            #region Iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            atrColaSimpleDatos.encolar(2000);
            atrColaSimpleDatos.encolar(5000);
            atrColaSimpleDatos.encolar(8000);

            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaSimpleDatos.desencolar(ref varElementoDesencolado);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(2, atrColaSimpleDatos.darLongitud());
            Assert.AreEqual(5000, atrColaSimpleDatos.darPrimero().darItem());
            Assert.AreEqual(8000, atrColaSimpleDatos.darUltimo().darItem());

            #endregion

        }
        [TestMethod]
        public void uTestDesencolarVaciarItemsCaso1()
        {
            #region iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            atrColaSimpleDatos.encolar(2000);

            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaSimpleDatos.desencolar(ref varElementoDesencolado);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(0, atrColaSimpleDatos.darLongitud());
            Assert.AreEqual(null, atrColaSimpleDatos.darPrimero());
            Assert.AreEqual(null, atrColaSimpleDatos.darUltimo()); //revisar caso extra

            #endregion

        }
        [TestMethod]
        public void uTestDesencolarVaciarItemsCaso2()
        {
            #region iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            atrColaSimpleDatos.encolar(2000);
            atrColaSimpleDatos.encolar(5000);

            bool varResultadoDesencolar;
            int varElementoDesencolado1 = 0;
            int varElementoDesencolado2 = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaSimpleDatos.desencolar(ref varElementoDesencolado1) && atrColaSimpleDatos.desencolar(ref varElementoDesencolado2);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado1);
            Assert.AreEqual(5000, varElementoDesencolado2);
            Assert.AreEqual(0, atrColaSimpleDatos.darLongitud());
            Assert.AreEqual(null, atrColaSimpleDatos.darPrimero());
            Assert.AreEqual(null, atrColaSimpleDatos.darUltimo());

            #endregion

        }
        #endregion
        #region casos de prueba revisar
        [TestMethod]
        public void uTestRevisarColaConItems()
        {
            #region Iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();
            atrColaSimpleDatos.encolar(2000);
            atrColaSimpleDatos.encolar(5000);

            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoRevisar = atrColaSimpleDatos.revisar(ref varElementoRevisado);
            Assert.AreEqual(true, varResultadoRevisar);
            Assert.AreEqual(2000, varElementoRevisado);

            #endregion

        }
        [TestMethod]
        public void uTestRevisarColaVacia()
        {
            #region Iniciar
            atrColaSimpleDatos = new clsColaSimpleEnlazada<int>();

            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoRevisar = atrColaSimpleDatos.revisar(ref varElementoRevisado);
            Assert.AreEqual(false, varResultadoRevisar);
            Assert.AreEqual(default(int), varElementoRevisado);
            #endregion
        }
        #endregion
        
    }
}
