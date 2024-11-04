using AccesoADatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaAccesoADatos
{
    [TestClass]
    public class PruebaGestionPartida
    {
        [TestMethod]
        public void PruebaRegistrarNuevaPartidaPorIdJugadorExitosa() 
        {
            int idJugador = 1;
            Partida partida = new Partida();
            partida.codigoPartida = "12345678";
            partida.modoJuego = "Facil";
            partida.estadoPartida = "Activa";
            GestionPartida gestionPartida = new GestionPartida();
            int resultadoEsperado = 1;
            int resultadoObtenido=gestionPartida.RegistrarNuevaPartidaPorIdJugador(idJugador, partida);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaActualizarEstadoDePartidaPorIdPartidaExitosa() 
        {
            int idPartida = 1;
            string estadoPartida = "Terminada";
            GestionPartida gestionPartida=new GestionPartida();
            int resultadoEsperado = 1;
            int resultadoObtenido=gestionPartida.ActualizarEstadoDePartidaPorIdPartida(idPartida, estadoPartida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarInexistenciaCodigoPartidaExitosa() 
        {
            string codigoPartida = "1234";
            int resultadoEsperado = 0;
            GestionPartida gestionPartida= new GestionPartida();    
            int resultadoObtenido=gestionPartida.ValidarInexistenciaCodigoPartida(codigoPartida);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarInexistenciaCodigoPartidaFallida() 
        {
            string codigoPartida = "12345678";
            int resultadoEsperado = 1;
            GestionPartida gestionPartida = new GestionPartida();
            int resultadoObtenido = gestionPartida.ValidarInexistenciaCodigoPartida(codigoPartida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaRecuperarPreguntasExitosa() 
        {
            int resultadoEsperado = 1;
            GestionPartida gestionPartida = new GestionPartida();
            List<Pregunta> preguntasObtenidas= gestionPartida.RecuperarPreguntas();            
            Pregunta preguntaObtenida = preguntasObtenidas.First();
            Assert.AreEqual(resultadoEsperado,preguntaObtenida.idPregunta);
        }

        [TestMethod]
        public void PruebaRecuperarRespuestasPorIdPreguntaExitosa() 
        {
            int idPregunta = 1;
            int resultadoEsperado = 1;
            GestionPartida gestionPartida= new GestionPartida();
            List<Respuesta> respuestasObtenidas = gestionPartida.RecuperarRespuestasPorIdPregunta(idPregunta);
            Respuesta respuestaObtenida = respuestasObtenidas.First();
            Assert.AreEqual(resultadoEsperado,respuestaObtenida.idRespuesta);
        }
    }
}
