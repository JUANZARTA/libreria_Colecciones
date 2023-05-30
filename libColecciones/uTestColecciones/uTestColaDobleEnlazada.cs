using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;

namespace uTestColecciones
{
    [TestClass]
    public class uTestColaDobleEnlazada
    {
        #region atributos de prueba
        clsColaDobleEnlazada<int> atrColaDobleleDatos;
        #endregion

        #region casos de pureba encolar
        [TestMethod]
        public void uTestEncolarunItem()
        {
            #region iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrColaDobleleDatos.encolar(2000));
            Assert.AreEqual(2000, atrColaDobleleDatos.darPrimero().darItem());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darSiguiente());
            Assert.AreEqual(2000, atrColaDobleleDatos.darUltimo().darItem());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darAnterior());
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo().darAnterior());
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(1, atrColaDobleleDatos.darLongitud());
            #endregion

        }
        [TestMethod]
        public void uTestEncolarDosItem()
        {
            #region iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrColaDobleleDatos.encolar(999));
            Assert.AreEqual(true, atrColaDobleleDatos.encolar(500));
            Assert.AreEqual(2, atrColaDobleleDatos.darLongitud());
            Assert.AreEqual(999, atrColaDobleleDatos.darPrimero().darItem());
            Assert.AreEqual(500, atrColaDobleleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darAnterior());
            Assert.AreEqual(500, atrColaDobleleDatos.darUltimo().darItem());
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(999, atrColaDobleleDatos.darUltimo().darAnterior().darItem());

            #endregion
        }
        [TestMethod]
        public void uTestEncolarVariosItem()
        {
            #region Iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrColaDobleleDatos.encolar(999));
            Assert.AreEqual(true, atrColaDobleleDatos.encolar(500));
            Assert.AreEqual(true, atrColaDobleleDatos.encolar(300));
            Assert.AreEqual(true, atrColaDobleleDatos.encolar(700));
            Assert.AreEqual(4, atrColaDobleleDatos.darLongitud());
            Assert.AreEqual(999, atrColaDobleleDatos.darPrimero().darItem());
            Assert.AreEqual(700, atrColaDobleleDatos.darUltimo().darItem());
            Assert.AreEqual(500, atrColaDobleleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(300, atrColaDobleleDatos.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(500, atrColaDobleleDatos.darUltimo().darAnterior().darAnterior().darItem());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darAnterior());
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(300, atrColaDobleleDatos.darUltimo().darAnterior().darItem());
            Assert.AreEqual(999, atrColaDobleleDatos.darPrimero().darSiguiente().darAnterior().darItem());
            Assert.AreEqual(500, atrColaDobleleDatos.darUltimo().darAnterior().darAnterior().darItem());
            Assert.AreEqual(999, atrColaDobleleDatos.darUltimo().darAnterior().darAnterior().darAnterior().darItem());


            #endregion

        }
        #endregion       
        #region casos de prueba Desencolar
        [TestMethod]
        public void uTestDesencolarConColaVacia()
        {
            #region iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaDobleleDatos.desencolar(ref varElementoDesencolado);
            Assert.AreEqual(false, varResultadoDesencolar);
            Assert.AreEqual(0, varElementoDesencolado);
            Assert.AreEqual(0, atrColaDobleleDatos.darLongitud());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero());
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo());

            #endregion

        }
        [TestMethod]
        public void uTestDesencolarUnItemCaso1()
        {
            #region Iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            atrColaDobleleDatos.encolar(2000);
            atrColaDobleleDatos.encolar(5000);
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaDobleleDatos.desencolar(ref varElementoDesencolado);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(1, atrColaDobleleDatos.darLongitud());
            Assert.AreEqual(5000, atrColaDobleleDatos.darPrimero().darItem());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darSiguiente());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darAnterior().darItem()); //error: retorna 2000(elemento desencolado)
            Assert.AreEqual(5000, atrColaDobleleDatos.darUltimo().darItem());
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo().darSiguiente());
            #endregion
        }
        [TestMethod]
        public void uTestDesencolarUnItemCaso2()
        {
            #region Iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            atrColaDobleleDatos.encolar(2000);
            atrColaDobleleDatos.encolar(5000);
            atrColaDobleleDatos.encolar(8000);
            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaDobleleDatos.desencolar(ref varElementoDesencolado);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(2, atrColaDobleleDatos.darLongitud());
            Assert.AreEqual(5000, atrColaDobleleDatos.darPrimero().darItem());
            Assert.AreEqual(8000, atrColaDobleleDatos.darUltimo().darItem());
            Assert.AreEqual(8000, atrColaDobleleDatos.darPrimero().darSiguiente().darItem()); 
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darAnterior()); //error: retorna 2000(valor desencolado) 
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(5000, atrColaDobleleDatos.darUltimo().darAnterior().darItem());
            atrColaDobleleDatos.darPrimero().darSiguiente().darItem();
            #endregion

        }
        [TestMethod]
        public void uTestDesencolarVaciarItemsCaso1()
        {
            #region iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            atrColaDobleleDatos.encolar(2000);

            bool varResultadoDesencolar;
            int varElementoDesencolado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaDobleleDatos.desencolar(ref varElementoDesencolado);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado);
            Assert.AreEqual(0, atrColaDobleleDatos.darLongitud());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero());
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo());

            #endregion

        }
        [TestMethod]
        public void uTestDesencolarVaciarItemsCaso2()
        {
            #region iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            atrColaDobleleDatos.encolar(2000);
            atrColaDobleleDatos.encolar(5000);

            bool varResultadoDesencolar;
            int varElementoDesencolado1 = 0;
            int varElementoDesencolado2 = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoDesencolar = atrColaDobleleDatos.desencolar(ref varElementoDesencolado1) && atrColaDobleleDatos.desencolar(ref varElementoDesencolado2);
            Assert.AreEqual(true, varResultadoDesencolar);
            Assert.AreEqual(2000, varElementoDesencolado1);
            Assert.AreEqual(5000, varElementoDesencolado2);
            Assert.AreEqual(0, atrColaDobleleDatos.darLongitud());
            Assert.AreEqual(null, atrColaDobleleDatos.darPrimero());
            Assert.AreEqual(null, atrColaDobleleDatos.darUltimo());
            //Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darSiguiente()); //Revisar da el siguiente de un elemento nulo
            //Assert.AreEqual(null, atrColaDobleleDatos.darPrimero().darAnterior()); //si no hay nodo no hay enlaces

            #endregion

        }
        #endregion
        #region casos de prueba revisar
        [TestMethod]
        public void uTestRevisarColaConItems()
        {
            #region Iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();
            atrColaDobleleDatos.encolar(2000);
            atrColaDobleleDatos.encolar(5000);

            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoRevisar = atrColaDobleleDatos.revisar(ref varElementoRevisado);
            Assert.AreEqual(true, varResultadoRevisar);
            Assert.AreEqual(2000, varElementoRevisado);

            #endregion

        }
        [TestMethod]
        public void uTestRevisarColaVacia()
        {
            #region Iniciar
            atrColaDobleleDatos = new clsColaDobleEnlazada<int>();

            bool varResultadoRevisar;
            int varElementoRevisado = 0;
            #endregion
            #region Probar y Comprobar
            varResultadoRevisar = atrColaDobleleDatos.revisar(ref varElementoRevisado);
            Assert.AreEqual(false, varResultadoRevisar);
            Assert.AreEqual(default(int), varElementoRevisado);
            #endregion
        }
        #endregion

    }
}
