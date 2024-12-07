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
    public class PruebaGestionPartidaExcepcion
    {
        [TestMethod]
        public void PruebaRegistrarNuevaPartidaPorIdJugadorExcepcion() 
        {
            int idJugador = 1;
            Partida partida = new Partida();
            partida.codigoPartida = "12345678";
            partida.modoJuego = "Facil";
            partida.estadoPartida = "Activa";
            GestionPartida gestionPartida = new GestionPartida();
            int resultadoEsperado = -1;
            int resultadoObtenido = gestionPartida.RegistrarNuevaPartidaPorIdJugador(idJugador, partida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaActualizarEstadoDePartidaPorIdPartidaExcepcion() 
        {
            int idPartida = 1;
            string estadoPartida = "Terminada";            
            int resultadoEsperado = -1;
            int resultadoObtenido = GestionPartida.ActualizarEstadoDePartidaPorIdPartida(idPartida, estadoPartida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarInexistenciaCodigoPartidaExcepcion()
        {
            string codigoPartida = "1234";
            int resultadoEsperado = -1;
            GestionPartida gestionPartida = new GestionPartida(); // Crear instancia
            int resultadoObtenido = gestionPartida.ValidarInexistenciaCodigoPartida(codigoPartida); // Usar instancia
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }


        [TestMethod]
        public void PruebaRecuperarPreguntasExcepcion() 
        {
            int resultadoEsperado = -1;
            GestionPartida gestionPartida = new GestionPartida();
            List<Pregunta> preguntasObtenidas = gestionPartida.RecuperarPreguntas();
            Pregunta preguntaObtenida = preguntasObtenidas.First();
            Assert.AreEqual(resultadoEsperado, preguntaObtenida.idPregunta);
        }

        [TestMethod]
        public void PruebaRecuperarRespuestasPorIdPreguntaExcepcion() 
        {
            int idPregunta = 1;
            int resultadoEsperado = -1;
            GestionPartida gestionPartida = new GestionPartida();
            List<Respuesta> respuestasObtenidas = gestionPartida.RecuperarRespuestasPorIdPregunta(idPregunta);
            Respuesta respuestaObtenida = respuestasObtenidas.First();
            Assert.AreEqual(resultadoEsperado, respuestaObtenida.idRespuesta);
        }
    }
}
