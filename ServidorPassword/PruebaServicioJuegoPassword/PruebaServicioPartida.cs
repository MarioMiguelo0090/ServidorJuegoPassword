using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaServicioJuegoPassword.ServidorPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaServicioJuegoPassword
{
    [TestClass]
    public class PruebaServicioPartida
    {
        [TestMethod]
        public void PruebaObtenerPuntajeExitoso()
        {
            string codigoPartida = "87651234";
            string jugador = "Miguel";
            List<string> jugadores= new List<string>();
            jugadores.Add(jugador);
            int numeroPreguntasTotales = 10;
            int numeroPregunta = 1;
            int resultadoEsperado = 20;
            ServicioPartidaClient servicioPartida = new ServicioPartidaClient();
            servicioPartida.ConfigurarJugadores(codigoPartida, jugadores.ToArray());
            servicioPartida.InicializarPartida(codigoPartida, numeroPreguntasTotales);
            servicioPartida.EvaluarPregunta(codigoPartida, jugador, numeroPregunta);
            int resultadoObtenido=servicioPartida.ObtenerPuntaje(codigoPartida, jugador);            
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }


        [TestMethod]
        public void PruebaObtenerPuntajeFallida() 
        {
            string codigoPartida = "11111111";
            string nombreUsuario = "Mario";
            ServicioPartidaClient servicioPartida= new ServicioPartidaClient();
            int resultadoEsperado = 0;
            int resultadoObtenido=servicioPartida.ObtenerPuntaje(codigoPartida, nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerGanadorExitosa() 
        {
            string codigoPartida = "22222222";
            string jugador = "Miguel";
            List<string> jugadores = new List<string>();
            jugadores.Add(jugador);
            int numeroPreguntasTotales = 10;
            int numeroPregunta = 1;            
            ServicioPartidaClient servicioPartida = new ServicioPartidaClient();
            servicioPartida.ConfigurarJugadores(codigoPartida, jugadores.ToArray());
            servicioPartida.InicializarPartida(codigoPartida, numeroPreguntasTotales);
            servicioPartida.EvaluarPregunta(codigoPartida, jugador, numeroPregunta);
            string resultadoEsperado = jugador;
            string resultadoObtenido=servicioPartida.ObtenerGanador(codigoPartida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerGanadorFallida() 
        {
            string codigoPartida = "12345678";
            ServicioPartidaClient servicioPartida =new ServicioPartidaClient();
            string resultadoEsperado = "";
            string resultadoObtenido = servicioPartida.ObtenerGanador(codigoPartida);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

    }
}
