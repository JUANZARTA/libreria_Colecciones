using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.DobleEnlazadas;

namespace UTestColecciones
{
    [TestClass]
    public class UTestListaDobleEnlazada
    {
        #region Atributos
        clsListaDobleEnlazada<int> atrListaDobleDatos;

        #endregion

        #region Casos de prueba Agregar
        [TestMethod]
        public void testAgregarUnItem()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            bool varResultadoAgregar;
            #endregion
            #region probar
            varResultadoAgregar = atrListaDobleDatos.agregar(2000);
            #endregion
            #region Comprobar
            Assert.AreEqual(true, varResultadoAgregar);
            Assert.AreEqual(1, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(2000, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrListaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darSiguiente());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darAnterior());


            #endregion
        }

        [TestMethod]
        public void testAgregarDosItems()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrListaDobleDatos.agregar(999));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(500));
            #endregion
            #region Comprobar
            Assert.AreEqual(2, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(999, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(500, atrListaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(500, atrListaDobleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(999, atrListaDobleDatos.darUltimo().darAnterior().darItem());

            #endregion
        }
        [TestMethod]
        public void testAgregarVariosItems()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            bool varResultadoAgregar = true;
            #endregion
            #region probar
            for (int varNumero = 0; varNumero < 500; varNumero++)
            {
                varResultadoAgregar = varResultadoAgregar && atrListaDobleDatos.agregar(varNumero);
            }

            #endregion

            #region Comprobar
            Assert.AreEqual(true, varResultadoAgregar);
            Assert.AreEqual(500, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(0, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(499, atrListaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(498, atrListaDobleDatos.darUltimo().darAnterior().darItem());
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente());

            #endregion
        }
        #endregion
        #region CasosDePruebaEncontrar

        [TestMethod]
        public void UTestEncontrarUnItemEnNodos()
        {
            #region Iniciar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            atrListaDobleDatos.agregar(2000);
            int atrIndiceEncontrado = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(2000, ref atrIndiceEncontrado));
            Assert.AreEqual(0, atrIndiceEncontrado);
            Assert.AreEqual(2000, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(1, atrListaDobleDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void UTestNoEncontrar()
        {
            #region Iniciar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrListaDobleDatos.agregar(2000);
            int atrIndiceEncontrado = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(false, atrListaDobleDatos.encontrar(200, ref atrIndiceEncontrado));
            Assert.AreEqual(0, atrIndiceEncontrado);
            Assert.AreEqual(2000, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(1, atrListaDobleDatos.darLongitud());
            #endregion
        }
        [TestMethod]

        public void testEncontrarEnItems()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            int atrIndice = 0;
            #endregion
            #region probar
            Assert.AreEqual(true, atrListaDobleDatos.agregar(999));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(500));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(200));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(100));
            #endregion
            #region Comprobar 
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(500, ref atrIndice));
            Assert.AreEqual(1, atrIndice);

            #endregion
        }
[TestMethod]
        public void testEncontrarEnItemscaso2()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            //bool varResultadoAgregar = false;
            int atrPosicion = 0;
            Assert.AreEqual(true, atrListaDobleDatos.agregar(999));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(500));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(200));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(100));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(600));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(400));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(222));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(333));
            #endregion

            #region Comprobar 
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(222, ref atrPosicion));
            Assert.AreEqual(6, atrPosicion);
            #endregion
        }

        #endregion
        #region TestInsertar
        [TestMethod]
        public void UTestInsertarItem()
        {
            #region Iniciar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrListaDobleDatos.agregar(2000);
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.insertar(0, 3));
            Assert.AreEqual(2, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(3, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(2000, atrListaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(2000, atrListaDobleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(3, atrListaDobleDatos.darUltimo().darAnterior().darItem());

            #endregion
        }
        [TestMethod]
        public void UTestInsertarItems()
        {
            #region Iniciar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();

            int atrPosicion = 0;
            Assert.AreEqual(true, atrListaDobleDatos.agregar(100));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(200));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(300));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(400));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(500));//600
            Assert.AreEqual(true, atrListaDobleDatos.agregar(700));
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.insertar(5, 600));
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(600, ref atrPosicion));
            Assert.AreEqual(5, atrPosicion);
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(500, ref atrPosicion));
            Assert.AreEqual(4, atrPosicion);
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(400, ref atrPosicion));
            Assert.AreEqual(3, atrPosicion);
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(300, ref atrPosicion));
            Assert.AreEqual(2, atrPosicion);
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(700, ref atrPosicion));
            Assert.AreEqual(6, atrPosicion);
            Assert.AreEqual(7, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(100, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());
            Assert.AreEqual(200, atrListaDobleDatos.darPrimero().darSiguiente().darItem());          
            Assert.AreEqual(300, atrListaDobleDatos.darPrimero().darSiguiente().darSiguiente().darItem());
            Assert.AreEqual(400, atrListaDobleDatos.darPrimero().darSiguiente().darSiguiente().darSiguiente().darItem());           
            Assert.AreEqual(700, atrListaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(600, atrListaDobleDatos.darUltimo().darAnterior().darItem());
            Assert.AreEqual(500, atrListaDobleDatos.darUltimo().darAnterior().darAnterior().darItem()); 
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente().darItem());

            #endregion
        }
        #endregion
        #region CasosDePruebaModificar
        [TestMethod]
        public void UTestModificarUnItem()
        {
            #region Iniciar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrListaDobleDatos.agregar(2000);
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.modificar(0, 3));
            Assert.AreEqual(1, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(3, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darSiguiente());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());

            #endregion
        }
        [TestMethod]
        public void UTestModificarItems()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrListaDobleDatos.agregar(999));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(500));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(100));
            int atrPosicion = 0;
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.modificar(1, 150));
            Assert.AreEqual(3, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(150, atrListaDobleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(true, atrListaDobleDatos.encontrar(150, ref atrPosicion));
            Assert.AreEqual(1, atrPosicion);
            Assert.AreEqual(3, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(150, atrListaDobleDatos.darUltimo().darAnterior().darItem());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente());
            #endregion
        }
        #endregion
        #region CasosDePruebaRemover
        [TestMethod]
        public void UTestRemoverVaciarItem()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrListaDobleDatos.agregar(999));
            int atrItemRemovido = default(int);
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.remover(0, ref atrItemRemovido));            
            Assert.AreEqual(999, atrItemRemovido);
            Assert.AreEqual(0, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero());
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo());
            #endregion



        }

        [TestMethod]
        public void UTestRemoverItems()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrListaDobleDatos.agregar(999));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(500));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(100));
            int atrItemRemovido = default(int);
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.remover(2, ref atrItemRemovido));            
            Assert.AreEqual(100, atrItemRemovido);
            Assert.AreEqual(2, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(999, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(500, atrListaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(999, atrListaDobleDatos.darUltimo().darAnterior().darItem());
            //Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());
            #endregion
        }
        [TestMethod]
        public void UTestRemoverItems2()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrListaDobleDatos.agregar(100));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(200));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(300));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(400));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(500));
            int atrItemRemovido = default(int);
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.remover(1, ref atrItemRemovido));
            Assert.AreEqual(200, atrItemRemovido);
            Assert.AreEqual(4, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(100, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(500, atrListaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(400, atrListaDobleDatos.darUltimo().darAnterior().darItem());
            Assert.AreEqual(300, atrListaDobleDatos.darPrimero().darSiguiente().darItem());
            Assert.AreEqual(300, atrListaDobleDatos.darUltimo().darAnterior().darAnterior().darItem());
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());
            #endregion
        }
        [TestMethod]
        public void UTestRemoverItems3()
        {
            #region Inicializar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            #endregion
            #region probar
            Assert.AreEqual(true, atrListaDobleDatos.agregar(100));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(200));
            Assert.AreEqual(true, atrListaDobleDatos.agregar(300));
            int atrItemRemovido = default(int);
            #endregion

            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.remover(1, ref atrItemRemovido));
            Assert.AreEqual(200, atrItemRemovido);
            Assert.AreEqual(2, atrListaDobleDatos.darLongitud());
            Assert.AreEqual(100, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(300, atrListaDobleDatos.darUltimo().darItem());
            Assert.AreEqual(100, atrListaDobleDatos.darUltimo().darAnterior().darItem());
            Assert.AreEqual(300, atrListaDobleDatos.darPrimero().darSiguiente().darItem());          
            Assert.AreEqual(null, atrListaDobleDatos.darUltimo().darSiguiente());
            Assert.AreEqual(null, atrListaDobleDatos.darPrimero().darAnterior());
            #endregion
        }
        #endregion
        #region CasosDePruebaRecuperar

        [TestMethod]
        public void UTestRecuperar()
        {
            #region Iniciar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrListaDobleDatos.agregar(2000);
            int atrItemEncontrado = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.recuperar(0, ref atrItemEncontrado));
            Assert.AreEqual(2000, atrItemEncontrado);
            Assert.AreEqual(2000, atrListaDobleDatos.darPrimero().darItem());
            Assert.AreEqual(1, atrListaDobleDatos.darLongitud());
            #endregion
        }

        [TestMethod]
        public void UTestRecuperarItems()
        {
            #region Iniciar
            atrListaDobleDatos = new clsListaDobleEnlazada<int>();
            bool varResultadoAgregar = true;
            varResultadoAgregar = atrListaDobleDatos.agregar(2000);
            varResultadoAgregar = atrListaDobleDatos.agregar(1000);
            varResultadoAgregar = atrListaDobleDatos.agregar(500);
            int atrItemEncontrado = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDobleDatos.recuperar(2, ref atrItemEncontrado));
            Assert.AreEqual(500, atrItemEncontrado);
            Assert.AreEqual(3, atrListaDobleDatos.darLongitud());
            #endregion
        }
        #endregion



    }


}