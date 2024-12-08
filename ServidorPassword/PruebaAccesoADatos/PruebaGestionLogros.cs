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
    public class PruebaGestionLogros
    {

        [TestMethod]
        public void PruebaRegistrarLogroPorIdJugadorExitosa()
        {
            int idJugador = 1;
            int idLogro = 1;
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionLogros.RegistrarLogroPorIdJugador(idJugador, idLogro);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRegistrarLogroPorIdJugadorFallida()
        {
            int idJugador = 1;
            int idLogro = -1;
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionLogros.RegistrarLogroPorIdJugador(idJugador, idLogro);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarRegistroLogroPorIdJugadorExitosa()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int idJugador = 1;
            int idLogro = 1;
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionLogros.VerificarRegistroLogroPorIdJugador(idJugador, idLogro);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarRegistroLogroPorIdJugadorFallida()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int idJugador = 1;
            int idLogro = 999;
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionLogros.VerificarRegistroLogroPorIdJugador(idJugador, idLogro);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerLogrosPorIdJugadorExitosa()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int idJugador = 11;
            List<int> resultadoEsperado = new List<int> { 1, 3 };
            List<int> resultadoObtenido = gestionLogros.ObtenerLogrosPorIdJugador(idJugador);
            CollectionAssert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerLogrosPorIdJugadorFallida()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int idJugador = 2;
            List<int> resultadoEsperado = new List<int>();
            List<int> resultadoObtenido = gestionLogros.ObtenerLogrosPorIdJugador(idJugador);
            CollectionAssert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCatalogoLogrosExitosa()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionLogros.VerificarCatalogoLogros();
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCatalogoLogrosFallida()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionLogros.VerificarCatalogoLogros();
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCumplimientoPrimerLogroPorIdEstadisticaExitosa()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int idEstadistica = 1;
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionLogros.VerificarCumplimientoPrimerLogroPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCumplimientoPrimerLogroPorIdEstadisticaFallido()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int idEstadistica = 3;
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionLogros.VerificarCumplimientoPrimerLogroPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCumplimientoSegundoLogroPorIdEstadisticaExitosa()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int idEstadistica = 2;
            int resultadoEsperado = 1;
            int resultadoObtenido = gestionLogros.VerificarCumplimientoSegundoLogroPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarCumplimientoSegundoLogroPorIdEstadisticaFallido()
        {
            GestionLogros gestionLogros = new GestionLogros();
            int idEstadistica = 4;
            int resultadoEsperado = 0;
            int resultadoObtenido = gestionLogros.VerificarCumplimientoSegundoLogroPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

    }
}
