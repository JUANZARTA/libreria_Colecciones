using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;

namespace uTestColecciones
{
    [TestClass]
    public class uTestPilaDobleleEnlazada
    {
        #region atributos de prueba
        clsPilaDobleEnlazada<int> atrPilaDobleDatos;
        int[] atrTestItems = new int[100];
        #endregion
        #region casos de pureba apilar
        [TestMethod]
        public void uTestApilarunItem()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrPilaDobleDatos.apilar(2000));
            Assert.AreEqual(2000, atrPilaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(null,atrPilaDobleDatos.darPrimero().darSiguiente());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero().darAnterior());
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo().darAnterior());
            Assert.AreEqual(1, atrPilaDobleDatos.darLongitud());
            #endregion

        }
        [TestMethod]
        public void uTestApilarDosItem()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrPilaDobleDatos.apilar(999));
            Assert.AreEqual(true, atrPilaDobleDatos.apilar(500));
            Assert.AreEqual(2, atrPilaDobleDatos.darLongitud());
            Assert.AreEqual(500, atrPilaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(999, atrPilaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(999, atrPilaDobleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero().darAnterior());
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(500, atrPilaDobleDatos.darUltimo().darAnterior().darItem());

            #endregion
        }
        [TestMethod]
        public void uTestApilarVariosItem()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrPilaDobleDatos.apilar(999));
            Assert.AreEqual(true, atrPilaDobleDatos.apilar(500));
            Assert.AreEqual(true, atrPilaDobleDatos.apilar(300));
            Assert.AreEqual(true, atrPilaDobleDatos.apilar(54));
            Assert.AreEqual(4, atrPilaDobleDatos.darLongitud());
            Assert.AreEqual(54, atrPilaDobleDatos.darPrimero().darItem()); 
            Assert.AreEqual(999, atrPilaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(300, atrPilaDobleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero().darAnterior());
            Assert.AreEqual(500, atrPilaDobleDatos.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(54, atrPilaDobleDatos.darPrimero().darSiguiente().darAnterior().darItem());
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(500, atrPilaDobleDatos.darUltimo().darAnterior().darItem());

            #endregion

        }
        #endregion
        #region casos de prueba Despailar
        [TestMethod]
        public void uTestDesapilarConPilaVacia()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaDobleDatos.desapilar(ref varElementoDesapilado);
            Assert.AreEqual(false, varResultadoDesapilar);
            Assert.AreEqual(0, varElementoDesapilado);
            Assert.AreEqual(0, atrPilaDobleDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero());
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo());

            #endregion

        }
        [TestMethod]
        public void uTestDesapilarUnItemCaso1()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDobleDatos.apilar(2000);
            atrPilaDobleDatos.apilar(5000);
            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaDobleDatos.desapilar(ref varElementoDesapilado);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(5000, varElementoDesapilado);
            Assert.AreEqual(1, atrPilaDobleDatos.darLongitud());
            Assert.AreEqual(2000, atrPilaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero().darSiguiente());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero().darAnterior()); //Error:el valor arrojado es 5000(Item desapilado)
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo().darAnterior()); //Error:el valor arrojado es 5000(Item desapilado)


            #endregion

        }
        [TestMethod]
        public void uTestDesapilarUnItemCaso2()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDobleDatos.apilar(2000);
            atrPilaDobleDatos.apilar(5000);
            atrPilaDobleDatos.apilar(8000);

            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaDobleDatos.desapilar(ref varElementoDesapilado);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(8000, varElementoDesapilado);
            Assert.AreEqual(2, atrPilaDobleDatos.darLongitud());
            Assert.AreEqual(5000, atrPilaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrPilaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(2000, atrPilaDobleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero().darAnterior().darItem()); //Error valor arrojado 800(item desapilado)
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(5000,atrPilaDobleDatos.darUltimo().darAnterior().darItem());
            #endregion

        }
        [TestMethod]
        public void uTestDesapilarVaciarItemsCaso1()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDobleDatos.apilar(2000);

            bool varResultadoDesapilar;
            int varElementoDesapilado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaDobleDatos.desapilar(ref varElementoDesapilado);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(2000, varElementoDesapilado);
            Assert.AreEqual(0, atrPilaDobleDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero());                        
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo()); 

            #endregion

        }
        [TestMethod]
        public void uTestDesapilarVaciarItemsCaso2()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDobleDatos.apilar(2000);
            atrPilaDobleDatos.apilar(5000);

            bool varResultadoDesapilar;
            int varElementoDesapilado1 = 0;
            int varElementoDesapilado2 = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesapilar = atrPilaDobleDatos.desapilar(ref varElementoDesapilado1) && atrPilaDobleDatos.desapilar(ref varElementoDesapilado2);
            Assert.AreEqual(true, varResultadoDesapilar);
            Assert.AreEqual(5000, varElementoDesapilado1);
            Assert.AreEqual(2000, varElementoDesapilado2);
            Assert.AreEqual(0, atrPilaDobleDatos.darLongitud());
            Assert.AreEqual(null, atrPilaDobleDatos.darPrimero());
            Assert.AreEqual(null, atrPilaDobleDatos.darUltimo());

            #endregion

        }
        #endregion
        #region casos de prueba revisar
        [TestMethod]
        public void uTestRevisarPilaConItems()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
            atrPilaDobleDatos.apilar(2000);
            atrPilaDobleDatos.apilar(5000);

            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoRevisar = atrPilaDobleDatos.revisar(ref varElementoRevisado);
            Assert.AreEqual(true, varResultadoRevisar);
            Assert.AreEqual(5000, varElementoRevisado);
            
            #endregion

        }
        [TestMethod]
        public void uTestRevisarPilaVacia()
        {
            #region Iniciar
            atrPilaDobleDatos = new clsPilaDobleEnlazada<int>();
  
            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoRevisar = atrPilaDobleDatos.revisar(ref varElementoRevisado);
            Assert.AreEqual(false, varResultadoRevisar);
            Assert.AreEqual(0,atrPilaDobleDatos.darLongitud());
            Assert.AreEqual(default(int), varElementoRevisado);
            #endregion
        }
        #endregion
    }
}
