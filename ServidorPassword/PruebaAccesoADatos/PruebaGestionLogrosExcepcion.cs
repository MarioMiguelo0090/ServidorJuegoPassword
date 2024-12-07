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
            int resultadoEsperado = -1;
            int resultadoObtenido = GestionLogros.VerificarRegistroLogroPorIdJugador(idJugadorInvalido, idLogro);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerLogrosPorIdJugadorExcepcion()
        {
            int idJugadorInvalido = -1;
            List<int> resultadoEsperado = new List<int> { -1 };
            List<int> resultadoObtenido = GestionLogros.ObtenerLogrosPorIdJugador(idJugadorInvalido);
            CollectionAssert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCatalogoLogrosExcepcion()
        {
            int resultadoEsperado = -1;
            int resultadoObtenido = GestionLogros.VerificarCatalogoLogros();
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCumplimientoPrimerLogroPorIdEstadisticaExcepcion()
        {
            int idEstadisticaInvalida = -1;
            int resultadoEsperado = -1;
            int resultadoObtenido = GestionLogros.VerificarCumplimientoPrimerLogroPorIdEstadistica(idEstadisticaInvalida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCumplimientoSegundoLogroPorIdEstadisticaExcepcion()
        {
            int idEstadisticaInvalida = -1;
            int resultadoEsperado = -1;
            int resultadoObtenido = GestionLogros.VerificarCumplimientoSegundoLogroPorIdEstadistica(idEstadisticaInvalida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
