using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Colecciones.Vectoriales;
using System.Linq;

namespace uTestColecciones
{
    [TestClass]
    public class uTestListaVector
    {
        #region Atributos de prueba
        clsListaVector<int> atrListaDatos;
        int atrItem;
        int atrIndice;
        int[] atrTestItems = new int[100];
        #endregion
        #region Casos de prueba
        /*  #region Test constructor parametrizado
           [TestMethod]
           public void uTestConstructorParametrizado()
           {
               #region iniciar
               atrTestItems = new int[4] { 0, 0, 0, 0 };
               atrListaDatos = new clsListaVector<int>(4);
               #endregion
               #region probar y comprobar
               Assert.AreEqual(4, atrListaDatos.darCapacidad());
               Assert.AreEqual(0, atrListaDatos.darLongitud());
               Assert.AreEqual(false, ReferenceEquals(null, atrListaDatos.darItems()));
               #endregion
           }
           #endregion*/
        #region TestAccesores
        [TestMethod]
        public void uTestDarCapacidad()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[2] { 1, 2 });
            #endregion
            #region probar y comprobar
            Assert.AreEqual(100, atrListaDatos.darCapacidad());
            #endregion
        }
        [TestMethod]
        public void uTestDarLongitud()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[] {1,2,3 });
            #endregion
            #region probar y comprobar
            Assert.AreEqual(3, atrListaDatos.darLongitud());
            #endregion
        }
        [TestMethod]
        public void uTestDarItems()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrTestItems = new int[100];
           
            #endregion
            #region probar y comprobar
            Assert.AreEqual(1, atrTestItems.Intersect(atrListaDatos.darItems()).Count());
          
            #endregion
        }
        #endregion
        #region Test Mutadores
        [TestMethod]
        public void TestPonerItems()
        {

            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrTestItems = new int[3] { 1, 2, 3 };
            #endregion
            #region Probar y Comprobar
            atrListaDatos.poner(new int[3] { 1, 2, 3 });
            Assert.AreEqual(3, atrTestItems.Intersect(atrListaDatos.darItems()).Count());
            #endregion
        }
        #endregion
        #region TestCruds
        #region uTestAgregar
        [TestMethod]
        public void AgregarItems() {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();

            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true,atrListaDatos.agregar(200));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(100,atrListaDatos.darCapacidad());
            Assert.AreEqual(true, atrListaDatos.agregar(30));
            Assert.AreEqual(2,atrListaDatos.darLongitud());
            Assert.AreEqual(30, atrListaDatos.darItems()[1]);
             

                #endregion
        }
        [TestMethod]
        public void AgregarHataLlenar()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>(2);
           

            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true, atrListaDatos.agregar(200));
            Assert.AreEqual(1, atrListaDatos.darLongitud());
            Assert.AreEqual(2, atrListaDatos.darCapacidad());
            Assert.AreEqual(true, atrListaDatos.agregar(30));
            Assert.AreEqual(2, atrListaDatos.darLongitud());
            Assert.AreEqual(30, atrListaDatos.darItems()[1]);
            Assert.AreEqual(false, atrListaDatos.agregar(1));


            #endregion
        }
        #endregion
        //#region uTestInsertar
        //[TestMethod]
        //public void InsertarItem()
        //{
        //    #region Iniciar
        //    atrListaDatos = new clsListaVector<int>();
        //    //atrListaDatos.ponerItems(new int[] { 5, 6, 7 });
        //    #endregion
        //    #region Probar y Comprobar

        //    Assert.AreEqual(true, atrListaDatos.agregar(5));
        //    Assert.AreEqual(true, atrListaDatos.agregar(6));
        //    Assert.AreEqual(true, atrListaDatos.agregar(7));
        //    Assert.AreEqual(3, atrListaDatos.darLongitud());
        //    Assert.AreEqual(true, atrListaDatos.insertar(1, 12));
        //    Assert.AreEqual(4, atrListaDatos.darLongitud());
        //    Assert.AreEqual(5, atrListaDatos.darItems()[0]);
        //    Assert.AreEqual(12, atrListaDatos.darItems()[1]);
        //    Assert.AreEqual(6, atrListaDatos.darItems()[2]);
        //    Assert.AreEqual(7,atrListaDatos.darItems()[3]);
        //    Assert.AreEqual(true, atrListaDatos.insertar(3, 26));
        //    Assert.AreEqual(5, atrListaDatos.darLongitud());
        //    Assert.AreEqual(5, atrListaDatos.darItems()[0]);
        //    Assert.AreEqual(12, atrListaDatos.darItems()[1]);
        //    Assert.AreEqual(6, atrListaDatos.darItems()[2]);
        //    Assert.AreEqual(26, atrListaDatos.darItems()[3]);
        //    Assert.AreEqual(7, atrListaDatos.darItems()[4]);
        //    Assert.AreEqual(true,atrListaDatos.insertar(0,99));
        //    Assert.AreEqual(6, atrListaDatos.darLongitud());
        //    Assert.AreEqual(99, atrListaDatos.darItems()[0]);
        //    Assert.AreEqual(5, atrListaDatos.darItems()[1]);
        //    Assert.AreEqual(12, atrListaDatos.darItems()[2]);
        //    Assert.AreEqual(6, atrListaDatos.darItems()[3]);
        //    Assert.AreEqual(26, atrListaDatos.darItems()[4]);
        //    Assert.AreEqual(7,atrListaDatos.darItems()[5]);


        //    #endregion
        //}
        //#endregion
     /* #region TestInsertar
        [TestMethod]
        public void UTestInsertarItem()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>(5);
            atrListaDatos.poner(new int[] { 1, 2, 3, 5 });
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDatos.insertar(3, 4));
            Assert.AreEqual(4, atrListaDatos.darItems()[3]);
            Assert.AreEqual(5, atrListaDatos.darLongitud());
            Assert.AreEqual(5, atrListaDatos.darItems()[4]);

            #endregion
        }
        [TestMethod]
        public void UTestInsertarItems()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>(5);
            atrListaDatos.poner(new int[] { 1, 2, 5 });
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDatos.insertar(2, 4));
            Assert.AreEqual(4, atrListaDatos.darItems()[2]);
            Assert.AreEqual(4, atrListaDatos.darLongitud());
            Assert.AreEqual(5, atrListaDatos.darItems()[3]);

            Assert.AreEqual(true, atrListaDatos.insertar(2, 3));
            Assert.AreEqual(3, atrListaDatos.darItems()[2]);
            Assert.AreEqual(5, atrListaDatos.darLongitud());
            Assert.AreEqual(5, atrListaDatos.darItems()[4]);

            #endregion
        }
        [TestMethod]
        public void UTestInsertarHastaLLenar()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>(5);
            atrListaDatos.poner(new int[] { 1, 2, 5 });
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDatos.insertar(2, 4));
            //Assert.AreEqual(4, atrListaDatos.darItems()[2]);
            //Assert.AreEqual(4, atrListaDatos.darLongitud());
            //Assert.AreEqual(5, atrListaDatos.darItems()[3]);

            //Assert.AreEqual(true, atrListaDatos.insertar(2, 3));
            //Assert.AreEqual(3, atrListaDatos.darItems()[2]);
            //Assert.AreEqual(5, atrListaDatos.darLongitud());
            //Assert.AreEqual(5, atrListaDatos.darItems()[4]);

            Assert.AreEqual(false, atrListaDatos.insertar(2, 99));


            #endregion
        }
        [TestMethod]
        public void UTestInsertarYremover()
        {
            #region Iniciar
            atrMiListaVector = new clsListaVector<int>(5);
            atrMiListaVector.poner(new int[] { 1, 2, 5 });
            atrItemRemovido = 0;
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaVector.insertar(2, 4));
            Assert.AreEqual(4, atrMiListaVector.darItems()[2]);
            Assert.AreEqual(4, atrMiListaVector.darLongitud());
            Assert.AreEqual(5, atrMiListaVector.darItems()[3]);

            Assert.AreEqual(true, atrMiListaVector.insertar(2, 3));
            Assert.AreEqual(3, atrMiListaVector.darItems()[2]);
            Assert.AreEqual(5, atrMiListaVector.darLongitud());
            Assert.AreEqual(5, atrMiListaVector.darItems()[4]);

            Assert.AreEqual(true, atrMiListaVector.remover(0, ref atrItemRemovido));
            Assert.AreEqual(1, atrItemRemovido);
            Assert.AreEqual(4, atrMiListaVector.darLongitud());

            Assert.AreEqual(true, atrMiListaVector.insertar(0, 99));


            Assert.AreEqual(false, atrMiListaVector.agregar(123));


            #endregion

        }

        [TestMethod]
        public void UTestInsertarUltimoIndice()
        {
            #region Iniciar
            atrMiListaVector = new clsListaVector<int>(5);
            atrMiListaVector.poner(new int[] { 1, 2, 3, 4, });
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrMiListaVector.insertar(4, 5));
            Assert.AreEqual(5, atrMiListaVector.darItems()[atrMiListaVector.darLongitud() - 1]);
            Assert.AreEqual(5, atrMiListaVector.darLongitud());

            #endregion
        }
        #endregion/*
        #region uTestRemover
        [TestMethod]
        public void RemoverItem() {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[] { 1,2,3,4});
            #endregion
            #region Probar y Comprobar
            Assert.AreEqual(true,atrListaDatos.remover(1,ref atrItem));
            Assert.AreEqual(100,atrListaDatos.darCapacidad());
            Assert.AreEqual(3,atrListaDatos.darLongitud());
            Assert.AreEqual(2,atrItem);
            Assert.AreEqual(3, atrListaDatos.darItems()[1]);
            Assert.AreEqual(1, atrListaDatos.darItems()[0]);
            Assert.AreEqual(4, atrListaDatos.darItems()[2]);
            Assert.AreEqual(true,atrListaDatos.remover(1,ref atrItem));
            Assert.AreEqual(2,atrListaDatos.darLongitud());
            Assert.AreEqual(3,atrItem );
            Assert.AreEqual(1,atrListaDatos.darItems()[0]);
            Assert.AreEqual(4, atrListaDatos.darItems()[1]);
            #endregion
        }
        #endregion
    */
        #region uTestModificar
        [TestMethod]
        public void ModificarItem() {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[] { 5, 6, 7 });
            #endregion

            #region Probar y Comprobar
            atrItem = 1;
            Assert.AreEqual(true,atrListaDatos.modificar(1, atrItem));
             Assert.AreEqual(3,atrListaDatos.darLongitud());
             Assert.AreEqual(1,atrListaDatos.darItems()[1]);
             Assert.AreEqual(false,atrListaDatos.modificar(4,2));
             Assert.AreEqual(5,atrListaDatos.darItems()[0]);
             Assert.AreEqual(7, atrListaDatos.darItems()[2]);
             Assert.AreEqual(true,atrListaDatos.modificar(0,3));
             Assert.AreEqual(3,atrListaDatos.darLongitud());
             Assert.AreEqual(3,atrListaDatos.darItems()[0]);
            //Assert.AreEqual(false,atrListaDatos.Modificar(1,atrItem));
    
            #endregion
        }
        #endregion
        #region uTestRecuperar
        [TestMethod]
        public void RecuperarItem()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[4] { 789,456,123,951});
            #endregion
            #region Probar y Coprobar
            Assert.AreEqual(true, atrListaDatos.recuperar(1,ref atrItem));
            Assert.AreEqual(456, atrItem);
            Assert.AreEqual(true,atrListaDatos.recuperar(3,ref atrItem));
            Assert.AreEqual(951,atrItem);
            Assert.AreEqual(true,atrListaDatos.recuperar(0,ref atrItem));
            Assert.AreEqual(789,atrItem);
            Assert.AreEqual(4,atrListaDatos.darLongitud());

            #endregion
        }
        #endregion
        #region uTestEncontrar()
        [TestMethod]
        public void EncontarItem()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[] {789,456,123,951 });
            #endregion
            #region probar y Comprobar
            Assert.AreEqual(true,atrListaDatos.encontrar(456,ref atrIndice ));
            Assert.AreEqual(1, atrIndice);
            Assert.AreEqual(true,atrListaDatos.encontrar(123, ref atrIndice));
            Assert.AreEqual(2,atrIndice);
            Assert.AreEqual(true, atrListaDatos.encontrar(789, ref atrIndice));
            Assert.AreEqual(0, atrIndice);
            #endregion
        }
        #endregion

        #endregion
        #region Test Metodos de ordenamiento
        [TestMethod]
        public void TestOrdenarPorSeleccion()
        {
            #region Iniciar
            atrListaDatos = new clsListaVector<int>();
            atrListaDatos.poner(new int[] { 8, 3, 4, 5, 5, 82, 10 });
            #endregion
            #region Probar y comprobar
            Assert.AreEqual(true, atrListaDatos.ordenarSeleccion(atrListaDatos.darItems()));
            Assert.AreEqual(7,atrListaDatos.darLongitud());
            Assert.AreEqual(3,atrListaDatos.darItems()[0]);
            Assert.AreEqual(4, atrListaDatos.darItems()[1]);
            Assert.AreEqual(5, atrListaDatos.darItems()[2]);
            Assert.AreEqual(5, atrListaDatos.darItems()[3]);
            Assert.AreEqual(8, atrListaDatos.darItems()[4]);
            Assert.AreEqual(10, atrListaDatos.darItems()[5]);
            Assert.AreEqual(82, atrListaDatos.darItems()[6]);
            #endregion
        }
        #endregion
        #endregion

    }
}
