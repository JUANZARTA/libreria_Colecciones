using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.SimpleEnlazadas;

namespace UTestColecciones
{
    [TestClass]
    public class UTestListaSimpleEnlazada
    {
        #region Atributos
        clsListaSimpleEnlazada<int> atrMiListaDatos;

        #endregion

        #region Casos de prueba Agregar
        [TestMethod]
        public void testAgregarUnItem()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            bool varResultadoAgregar;
            #endregion
            #region probar
            varResultadoAgregar = atrMiListaDatos.agregar(2000);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoAgregar);
            Assert.AreEqual(2000, atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrMiListaDatos.darUltimo().darItem());
            Assert.AreEqual(1, atrMiListaDatos.darLongitud());

            #endregion
        }

        [TestMethod]
        public void testAgregarDosItems()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrMiListaDatos.agregar(999));
            Assert.AreEqual(true, atrMiListaDatos.agregar(500));
            #endregion
            #region Comprobar
            Assert.AreEqual(999, atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(500, atrMiListaDatos.darUltimo().darItem());
            Assert.AreEqual(2, atrMiListaDatos.darLongitud());
            #endregion
        }



        [TestMethod]
        public void testAgregarVariosItems()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            bool varResultadoAgregar = true;
            #endregion
            #region probar
            for (int varNumero = 0; varNumero < 500; varNumero++)
            {
                varResultadoAgregar = varResultadoAgregar && atrMiListaDatos.agregar(varNumero);
            }

            #endregion

            #region Comprobar
            Assert.AreEqual(true, varResultadoAgregar);
            Assert.AreEqual(500, atrMiListaDatos.darLongitud());
            Assert.AreEqual(0, atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(499, atrMiListaDatos.darUltimo().darItem());

            #endregion
        }
        #endregion


        #region CasosDePruebaEncontrar

        [TestMethod]
        public void UTestEncontrarUnItemEnNodos()
        {
            #region Iniciar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            atrMiListaDatos.agregar(2000);
            int atrIndiceEncontrado = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.encontrar(2000, ref atrIndiceEncontrado));
            Assert.AreEqual(0, atrIndiceEncontrado);
            Assert.AreEqual(2000, atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(1, atrMiListaDatos.darLongitud());
            #endregion
        }



        [TestMethod]
        public void UTestNoEncontrar()
        {
            #region Iniciar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrMiListaDatos.agregar(2000);
            int atrIndiceEncontrado = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(false, atrMiListaDatos.encontrar(200, ref atrIndiceEncontrado));
            Assert.AreEqual(0, atrIndiceEncontrado);
            Assert.AreEqual(2000, atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(1, atrMiListaDatos.darLongitud());
            #endregion
        }


        [TestMethod]

        public void testEncontrarEnItems()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            int atrIndice = 0;
            #endregion
            #region probar
            Assert.AreEqual(true, atrMiListaDatos.agregar(999));
            Assert.AreEqual(true, atrMiListaDatos.agregar(500));
            Assert.AreEqual(true, atrMiListaDatos.agregar(200));
            Assert.AreEqual(true, atrMiListaDatos.agregar(100));
            #endregion
            #region Comprobar 
            Assert.AreEqual(true, atrMiListaDatos.encontrar(500, ref atrIndice));
            Assert.AreEqual(1, atrIndice);

            #endregion
        }

        public void testEncontrarEnItemscaso2()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            //bool varResultadoAgregar = false;
            int atrPosicion = 0;
            Assert.AreEqual(true, atrMiListaDatos.agregar(999));
            Assert.AreEqual(true, atrMiListaDatos.agregar(500));
            Assert.AreEqual(true, atrMiListaDatos.agregar(200));
            Assert.AreEqual(true, atrMiListaDatos.agregar(100));
            Assert.AreEqual(true, atrMiListaDatos.agregar(600));
            Assert.AreEqual(true, atrMiListaDatos.agregar(400));
            Assert.AreEqual(true, atrMiListaDatos.agregar(222));
            Assert.AreEqual(true, atrMiListaDatos.agregar(333));
            #endregion

            #region Comprobar 
            Assert.AreEqual(true, atrMiListaDatos.encontrar(222, ref atrPosicion));
            Assert.AreEqual(6, atrPosicion);
            #endregion
        }

        #endregion

        #region TestInsertar
        [TestMethod]
        public void UTestInsertarItem()
        {
            #region Iniciar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrMiListaDatos.agregar(2000);
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.insertar(0, 3));
            Assert.AreEqual(3, atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrMiListaDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(2, atrMiListaDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void UTestInsertarItems()
        {
            #region Iniciar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();

            int atrPosicion = 0;
            Assert.AreEqual(true, atrMiListaDatos.agregar(999));
            Assert.AreEqual(true, atrMiListaDatos.agregar(500));
            Assert.AreEqual(true, atrMiListaDatos.agregar(200));
            Assert.AreEqual(true, atrMiListaDatos.agregar(100));
            Assert.AreEqual(true, atrMiListaDatos.agregar(600));
            Assert.AreEqual(true, atrMiListaDatos.agregar(400));           
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.insertar(5, 2000));
            Assert.AreEqual(true, atrMiListaDatos.encontrar(2000, ref atrPosicion));
            Assert.AreEqual(5, atrPosicion);
            Assert.AreEqual(999,atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(500, atrMiListaDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(200, atrMiListaDatos.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(100, atrMiListaDatos.darPrimero().darSiguiente().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(600, atrMiListaDatos.darPrimero().darSiguiente().darSiguiente().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(2000, atrMiListaDatos.darPrimero().darSiguiente().darSiguiente().darSiguiente().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(400,atrMiListaDatos.darUltimo().darItem());
            Assert.AreEqual(7, atrMiListaDatos.darLongitud());
            #endregion
        }
        #endregion

        #region CasosDePruebaModificar
        [TestMethod]
        public void UTestModificarUnItem()
        {
            #region Iniciar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrMiListaDatos.agregar(2000);
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.modificar(0, 3));
            Assert.AreEqual(3, atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(1, atrMiListaDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void UTestModificarItems()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrMiListaDatos.agregar(999));
            Assert.AreEqual(true, atrMiListaDatos.agregar(500));
            Assert.AreEqual(true, atrMiListaDatos.agregar(100));
            int atrPosicion = 0;
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.modificar(1, 150));
            Assert.AreEqual(150, atrMiListaDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(true, atrMiListaDatos.encontrar(150, ref atrPosicion));
            Assert.AreEqual(1, atrPosicion);
            Assert.AreEqual(3, atrMiListaDatos.darLongitud());
            #endregion
        }




        #endregion

        #region CasosDePruebaRemover
        [TestMethod]
        public void UTestRemoverItem()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrMiListaDatos.agregar(999));
            int atrItemRemovido = default(int);
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.remover(0, ref atrItemRemovido));
            Assert.AreEqual(null, atrMiListaDatos.darPrimero());
            Assert.AreEqual(999, atrItemRemovido);
            Assert.AreEqual(0, atrMiListaDatos.darLongitud());
            #endregion

            

        }

        [TestMethod]
        public void UTestRemoverItems()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrMiListaDatos.agregar(999));
            Assert.AreEqual(true, atrMiListaDatos.agregar(500));
            Assert.AreEqual(true, atrMiListaDatos.agregar(100));
            int atrItemRemovido = default(int);
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.remover(2, ref atrItemRemovido));
            Assert.AreEqual(500, atrMiListaDatos.darUltimo().darItem());
            Assert.AreEqual(100, atrItemRemovido);
            Assert.AreEqual(2, atrMiListaDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void UTestRemoverItems2()
        {
            #region Inicializar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrMiListaDatos.agregar(999));
            Assert.AreEqual(true, atrMiListaDatos.agregar(500));
            Assert.AreEqual(true, atrMiListaDatos.agregar(100));
            int atrItemRemovido = default(int);
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.remover(1, ref atrItemRemovido));
            Assert.AreEqual(500,atrItemRemovido);
            Assert.AreEqual(100, atrMiListaDatos.darUltimo().darItem());
            Assert.AreEqual(2, atrMiListaDatos.darLongitud());
            Assert.AreEqual(999, atrMiListaDatos.darPrimero().darItem());

            #endregion
        }
        #endregion


        #region CasosDePruebaRecuperar

        [TestMethod]
        public void UTestRecuperar()
        {
            #region Iniciar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrMiListaDatos.agregar(2000);
            int atrItemEncontrado = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.recuperar(0, ref atrItemEncontrado));
            Assert.AreEqual(2000, atrItemEncontrado);
            Assert.AreEqual(2000, atrMiListaDatos.darPrimero().darItem());
            Assert.AreEqual(1, atrMiListaDatos.darLongitud());
            #endregion
        }

        [TestMethod]
        public void UTestRecuperarItems()
        {
            #region Iniciar
            atrMiListaDatos = new clsListaSimpleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrMiListaDatos.agregar(2000);
            varResultadoAgregar = atrMiListaDatos.agregar(1000);
            varResultadoAgregar = atrMiListaDatos.agregar(500);
            int atrItemEncontrado = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaDatos.recuperar(2, ref atrItemEncontrado));
            Assert.AreEqual(500, atrItemEncontrado);
            Assert.AreEqual(3, atrMiListaDatos.darLongitud());
            #endregion
        }
        #endregion



    }


}
