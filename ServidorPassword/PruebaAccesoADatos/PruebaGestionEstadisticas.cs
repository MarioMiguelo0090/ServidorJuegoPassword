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
    public class PruebaGestionEstadisticas
    {
        [TestMethod]
        public void PruebaAgregarPuntajePorIdEtadisticaExitosa() 
        {
            int idEstadistica = 1;
            int puntajeAAgregar = 10;
            int resultadoEsperado = 1;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPuntajePorIdEstadistica(idEstadistica, puntajeAAgregar);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaAgregarPuntajePorIdEstadisticaFallida()
        {
            int idEstadistica = 0;
            int puntajeAAgregar = 10;
            int resultadoEsperado = 0;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPuntajePorIdEstadistica(idEstadistica, puntajeAAgregar);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaAgregarPartidaGanadaPorIdEstadisticaExitosa() 
        {
            int idEstadistica = 1;
            int resultadoEsperado = 1;
            GestionEstadisticas gestionEstadisticas=new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPartidaGanadaPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaAgregarPartidaGanadaPorIdEstadisticaFallida() 
        {
            int idEstadistica = 0;
            int resultadoEsperado = 0;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPartidaGanadaPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaAgregarPartidaPerdidaPorIdEstadisticaExitosa() 
        {
            int idEstadistica = 1;
            int resultadoEsperado = 1;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPartidaGanadaPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaAgregarPartidaPerdidaPorIdEstadisticaFallida()
        {
            int idEstadistica = 0;
            int resultadoEsperado = 0;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            int resultadoObtenido = gestionEstadisticas.AgregarPartidaGanadaPorIdEstadistica(idEstadistica);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerEstadisticaPorIdEstadisticaExitosa() 
        {
            int idEstadistica = 1;            
            int resultadoEsperado = 1;  
            GestionEstadisticas gestionEstadisticas=new GestionEstadisticas();
            Estadistica estadisticaObtenida=gestionEstadisticas.ObtenerEstadisticaPorIdEstadistica(idEstadistica);
            int resultadoObtenido = estadisticaObtenida.idEstadistica;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }


        [TestMethod]
        public void PruebaObtenerEstadisticaPorIdEstadisticaFallida()
        {
            int idEstadistica = 0;         
            int resultadoEsperado = 0;
            GestionEstadisticas gestionEstadisticas = new GestionEstadisticas();
            Estadistica estadisticaObtenida = gestionEstadisticas.ObtenerEstadisticaPorIdEstadistica(idEstadistica);
            int resultadoObtenido = estadisticaObtenida.idEstadistica;
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

    }
}
