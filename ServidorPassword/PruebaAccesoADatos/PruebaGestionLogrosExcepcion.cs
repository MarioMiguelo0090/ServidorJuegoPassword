using AccesoADatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionLogrosExcepcion
    {
        [TestMethod]
        public void PruebaRegistrarLogroPorIdJugadorExcepcion()
        {
            int idJugadorInvalido = -1;
            int idLogro = 1;
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionLogros.RegistrarLogroPorIdJugador(idJugadorInvalido, idLogro);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarRegistroLogroPorIdJugadorExcepcion()
        {
            int idJugadorInvalido = -1;
            int idLogro = 1;
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionLogros.VerificarRegistroLogroPorIdJugador(idJugadorInvalido, idLogro);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerLogrosPorIdJugadorExcepcion()
        {
            int idJugadorInvalido = -1;
            GestionLogros gestionLogros = new GestionLogros();
            List<int> resultadoEsperado = new List<int> { -1 };
            List<int> resultadoObtenido = gestionLogros.ObtenerLogrosPorIdJugador(idJugadorInvalido);
            CollectionAssert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCatalogoLogrosExcepcion()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionLogros.VerificarCatalogoLogros();
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCumplimientoPrimerLogroPorIdEstadisticaExcepcion()
        {
            int idEstadisticaInvalida = -1;
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionLogros.VerificarCumplimientoPrimerLogroPorIdEstadistica(idEstadisticaInvalida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCumplimientoSegundoLogroPorIdEstadisticaExcepcion()
        {
            int idEstadisticaInvalida = -1;
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionLogros.VerificarCumplimientoSegundoLogroPorIdEstadistica(idEstadisticaInvalida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
