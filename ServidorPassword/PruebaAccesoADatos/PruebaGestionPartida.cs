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
        public void PruebaRegistrarNuevaPartidaPorIdJugadorFallida() 
        {
            int idJugador = 0;
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
        public void PruebaActualizarEstadoDePartidaPorIdPartidaExitosa() 
        {
            int idPartida = 1;
            string estadoPartida = "Terminada";            
            int resultadoEsperado = 1;
            int resultadoObtenido=GestionPartida.ActualizarEstadoDePartidaPorIdPartida(idPartida, estadoPartida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaActualizarEstadoDePartidaPorIdPartidaFallida() 
        {
            int idPartida = 0;
            string estadoPartida = "Terminada";            
            int resultadoEsperado = 0;
            int resultadoObtenido = GestionPartida.ActualizarEstadoDePartidaPorIdPartida(idPartida, estadoPartida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarInexistenciaCodigoPartidaExitosa() 
        {
            string codigoPartida = "1234";
            int resultadoEsperado = 0;            
            int resultadoObtenido=GestionPartida.ValidarInexistenciaCodigoPartida(codigoPartida);
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaValidarInexistenciaCodigoPartidaFallida() 
        {
            string codigoPartida = "12345678";
            int resultadoEsperado = 1;            
            int resultadoObtenido = GestionPartida.ValidarInexistenciaCodigoPartida(codigoPartida);
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
        public void PruebaRecuperarPreguntasFallida() 
        {
            int resultadoEsperado = 0;
            GestionPartida gestionPartida = new GestionPartida();
            List<Pregunta> preguntasObtenidas = gestionPartida.RecuperarPreguntas();
            int resultadoObtenido = preguntasObtenidas.Count();
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
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

        [TestMethod]
        public void PruebaRecuperarRespuestasPorIdPreguntaFallida() 
        {
            int idPregunta = 0;
            int resultadoEsperado = 0;
            GestionPartida gestionPartida = new GestionPartida();
            List<Respuesta> respuestasObtenidas = gestionPartida.RecuperarRespuestasPorIdPregunta(idPregunta);
            int resultadoObtenido = respuestasObtenidas.Count();
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerPartidaPorCodigoPartidaExitosa() 
        {
            string codigoPartida = "71582435";
            int idPartidaEsperado = 1;            
            Partida partidaObtenida=GestionPartida.ObtenerPartidaPorCodigoPartida(codigoPartida);
            int idPartidaObtenido = partidaObtenida.idPartida;
            Assert.AreEqual(idPartidaEsperado,idPartidaObtenido);
        }

        [TestMethod]
        public void PruebaObtenerPartidaPorCodigoPartidaFallida()
        {
            string codigoPartida = "7158243";                        
            Partida partidaObtenida = GestionPartida.ObtenerPartidaPorCodigoPartida(codigoPartida);
            Assert.IsNull(partidaObtenida);
        }

        [TestMethod]
        public void PruebaObtenerRespuestasPorIdPreguntasExitosa() 
        {
            int resultadoEsperado = 6;
            List<int> idPreguntas = new List<int>();
            idPreguntas.Add(1);
            idPreguntas.Add(2);
            GestionPartida gestionPartida=new GestionPartida();
            List<Respuesta> respuestasObtenidas=gestionPartida.ObtenerRespuestasPorIdPreguntas(idPreguntas);
            int resultadoObtenido=respuestasObtenidas.Count;
            Assert.AreEqual(resultadoEsperado,resultadoObtenido);
        }
    }
}
