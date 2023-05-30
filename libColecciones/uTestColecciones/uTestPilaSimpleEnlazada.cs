using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.SimpleEnlazadas;

namespace uTestColecciones
{
    [TestClass]
    public class uTestPilaSimpleEnlazada
    {
        #region atributos de prueba
        clsPilaSimpleEnlazada<int> atrPilaSimpleDatos;
        int[] atrTestItems = new int[100];
        #endregion
        
        #region casos de pureba apilar
        [TestMethod]
        public void uTestApilarunItem()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrPilaSimpleDatos.apilar(2000));
            Assert.AreEqual(2000, atrPilaSimpleDatos.darPrimero().darItem());  
            Assert.AreEqual(2000, atrPilaSimpleDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrPilaSimpleDatos.darLongitud());
            #endregion

        }
        [TestMethod]
        public void uTestApilarDosItem()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrPilaSimpleDatos.apilar(999));
            Assert.AreEqual(true, atrPilaSimpleDatos.apilar(500));
            Assert.AreEqual(2, atrPilaSimpleDatos.darLongitud());
            Assert.AreEqual(500, atrPilaSimpleDatos.darPrimero().darItem());  // dar nodoprimero o dar primero
            Assert.AreEqual(999, atrPilaSimpleDatos.darUltimo().darItem());

            #endregion
        }
        [TestMethod]
        public void uTestApilarVariosItem()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrPilaSimpleDatos.apilar(999));
            Assert.AreEqual(true, atrPilaSimpleDatos.apilar(500));
            Assert.AreEqual(true, atrPilaSimpleDatos.apilar(300));
            Assert.AreEqual(3, atrPilaSimpleDatos.darLongitud());
            Assert.AreEqual(300, atrPilaSimpleDatos.darPrimero().darItem());  // dar nodoprimero o dar primero
            Assert.AreEqual(999, atrPilaSimpleDatos.darUltimo().darItem());

            #endregion
            
        }
        #endregion
        #region casos de prueba Despailar
        [TestMethod]
        public void uTestDesapilarConPilaVacia()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaSimpleDatos.desapilar(ref varElementoDesapilado);
            Assert.AreEqual(false, varResultadoDesapilar);
            Assert.AreEqual(0, varElementoDesapilado);  
            Assert.AreEqual(0, atrPilaSimpleDatos.darLongitud());
            Assert.AreEqual(null, atrPilaSimpleDatos.darPrimero());
            Assert.AreEqual(null, atrPilaSimpleDatos.darUltimo());

            #endregion

        }
        [TestMethod]
        public void uTestDesapilarUnItemCaso1()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            atrPilaSimpleDatos.apilar(2000);
            atrPilaSimpleDatos.apilar(5000);
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaSimpleDatos.desapilar(ref varElementoDesapilado);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(5000, varElementoDesapilado);
            Assert.AreEqual(1, atrPilaSimpleDatos.darLongitud());
            Assert.AreEqual(2000, atrPilaSimpleDatos.darPrimero().darItem());  
            Assert.AreEqual(2000, atrPilaSimpleDatos.darUltimo().darItem());

            #endregion

        }
        [TestMethod]
        public void uTestDesapilarUnItemCaso2()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            atrPilaSimpleDatos.apilar(2000);
            atrPilaSimpleDatos.apilar(5000);
            atrPilaSimpleDatos.apilar(8000);

            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaSimpleDatos.desapilar(ref varElementoDesapilado);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(8000, varElementoDesapilado);
            Assert.AreEqual(2, atrPilaSimpleDatos.darLongitud());
            Assert.AreEqual(5000, atrPilaSimpleDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaSimpleDatos.darUltimo().darItem());

            #endregion

        }
        [TestMethod]
        public void uTestDesapilarVaciarItemsCaso1()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            atrPilaSimpleDatos.apilar(2000);
         
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaSimpleDatos.desapilar(ref varElementoDesapilado);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(2000, varElementoDesapilado);
            Assert.AreEqual(0, atrPilaSimpleDatos.darLongitud());
            Assert.AreEqual(null, atrPilaSimpleDatos.darPrimero());
            Assert.AreEqual(null, atrPilaSimpleDatos.darUltimo()); //revisar caso extra

            #endregion

        }
        [TestMethod]
        public void uTestDesapilarVaciarItemsCaso2()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            atrPilaSimpleDatos.apilar(2000);
            atrPilaSimpleDatos.apilar(5000);

            bool varResultadoDesapilar;
            int varElementoDesapilado1 = 0;
            int varElementoDesapilado2 = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaSimpleDatos.desapilar(ref varElementoDesapilado1) && atrPilaSimpleDatos.desapilar(ref varElementoDesapilado2);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(5000, varElementoDesapilado1);
            Assert.AreEqual(2000, varElementoDesapilado2);
            Assert.AreEqual(0, atrPilaSimpleDatos.darLongitud());
            Assert.AreEqual(null, atrPilaSimpleDatos.darPrimero());
            Assert.AreEqual(null, atrPilaSimpleDatos.darUltimo()); 

            #endregion

        }
        #endregion
        #region casos de prueba revisar
        [TestMethod]
        public void uTestRevisarPilaConItems()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
            atrPilaSimpleDatos.apilar(2000);
            atrPilaSimpleDatos.apilar(5000);

            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoRevisar = atrPilaSimpleDatos.revisar(ref varElementoRevisado);
            Assert.AreEqual(true, varResultadoRevisar);
            Assert.AreEqual(5000, varElementoRevisado);
            
            #endregion

        }
        [TestMethod]
        public void uTestRevisarPilaVacia()
        {
            #region Iniciar
            atrPilaSimpleDatos = new clsPilaSimpleEnlazada<int>();
  
            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoRevisar = atrPilaSimpleDatos.revisar(ref varElementoRevisado);
            Assert.AreEqual(false, varResultadoRevisar);
            Assert.AreEqual(0,atrPilaSimpleDatos.darLongitud());
            Assert.AreEqual(default(int), varElementoRevisado);
            #endregion
        }
        #endregion

    }

}