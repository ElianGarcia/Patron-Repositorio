using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.BLL.Tests
{
    [TestClass()]
    public class GenericaBLLTests
    {
        [TestMethod()]
        public void BuscarTest()
        {
            GenericaBLL<Empleados> genericaBLL = new GenericaBLL<Empleados>();
            Empleados empleado;
            empleado = genericaBLL.Buscar(1);
            Assert.IsNotNull(empleado);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            GenericaBLL<Empleados> genericaBLL = new GenericaBLL<Empleados>();
            bool realizado = genericaBLL.Eliminar(1);
            Assert.AreEqual(realizado, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            GenericaBLL<Empleados> genericaBLL = new GenericaBLL<Empleados>();
            List<Empleados> listado = new List<Empleados>();

            listado = genericaBLL.GetList(p => true);
            Assert.IsNotNull(listado);
        }

        [TestMethod()]
        public void GuardarTest()
        {
            GenericaBLL<Empleados> repositorio = new GenericaBLL<Empleados>();
            Empleados e = new Empleados(0, DateTime.Now, "Martin", "En su casa", "8296547855", "9086549875", "La que le vendio a gonzalo", 52.36, 15.00);
            Assert.IsTrue(repositorio.Guardar(e));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            GenericaBLL<Empleados> repositorio = new GenericaBLL<Empleados>();
            Empleados e1 = new Empleados(1, DateTime.Now, "Lennigton", "En su casa", "8296547855", "9086549875", "La que le vendio a gonzalo", 52.36, 15.00);
            Assert.AreEqual(repositorio.Modificar(e1), true);
        }
    }
}