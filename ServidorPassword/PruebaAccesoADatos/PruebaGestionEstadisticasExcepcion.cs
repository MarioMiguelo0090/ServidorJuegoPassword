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
    public class PruebaGestionEstadisticasExcepcion
    {
        [TestMethod]
        public void PruebaAgregarPuntajePorIdEstadisticaExcepcion()
        {
            int idEstadistica = -1;
            int puntajeAAgregar = 10;
            int resultadoEsperado = -1;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPuntajePorIdEstadistica(idEstadistica, puntajeAAgregar);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaAgregarPartidaGanadaPorIdEstadisticaExcepcion()
        {
            int idEstadistica = -1;
            int resultadoEsperado = -1;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPartidaGanadaPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaAgregarPartidaPerdidaPorIdEstadisticaExcepcion()
        {
            int idEstadistica = -1; 
            int resultadoEsperado = -1;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPartidaPerdidaPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerEstadisticaPorIdEstadisticaExcepcion()
        {
            int idEstadistica = -1;
            Estadistica resultadoEsperado = null;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            Estadistica resultadoObtenido = gestionEstadisticas.ObtenerEstadisticaPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}
