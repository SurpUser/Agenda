using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Tests
{
    [TestClass()]
    public class PersonasTests
    {
        Personas persona = new Personas();
        [TestMethod()]
        public void PersonasTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AgregarTelefonosTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LimpiarListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.IsTrue(persona.Buscar(10));
        }

        [TestMethod()]
        public void EditarTest()
        {
            persona.PersonaId = 11;
            persona.Nombre = "Francis";
            persona.Direccion = "Tenares";
            persona.sexo = 1;
            persona.EstadoCivil = 1;
            persona.AgregarTelefonos(1, "8293912345");
            Assert.IsTrue(persona.Editar());
        }

        [TestMethod()]
        public void EliminarTest()
        {
            persona.PersonaId = 12;
            Assert.IsTrue(persona.Eliminar());
        }

        [TestMethod()]
        public void InsertarTest()
        {
            persona.Nombre = "Francis";
            persona.Direccion = "Tenares";
            persona.sexo = 1;
            persona.EstadoCivil = 1;
            persona.AgregarTelefonos(1,"8293912345");
            Assert.IsTrue(persona.Insertar());
        }

        [TestMethod()]
        public void ListadoTest()
        {
            Assert.IsTrue(persona.Listado(" * "," 1=1 ","").Rows.Count == 2);
        }
    }
}