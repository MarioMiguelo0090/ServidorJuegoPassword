using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaServicioJuegoPassword.ServidorPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PruebaServicioJuegoPassword
{
    [TestClass]
    public class PruebaServicioJugadores
    {

        [TestMethod]
        public void PruebaConectarJugadorJuegoExitosa() 
        {
            ServicioJugadoresClient servicioJugadores = new ServicioJugadoresClient();
            string nombreUsuario = "Miguel";
            int resultadoEsperado = 1;
            int resultadoObtenido= servicioJugadores.ConectarJugadorJuego(nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaConectarJugadorJuegoFallida()
        {
            ServicioJugadoresClient servicioJugadores = new ServicioJugadoresClient();
            string nombreUsuario = "Jack";
            int resultadoEsperado = 0;
            servicioJugadores.ConectarJugadorJuego(nombreUsuario);
            int resultadoObtenido = servicioJugadores.ConectarJugadorJuego(nombreUsuario);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerJugadoresExitosa() 
        {
            ServicioJugadoresClient servicioJugadores = new ServicioJugadoresClient();
            string nombreUsuario = "Mario";
            servicioJugadores.ConectarJugadorJuego(nombreUsuario);
            List<string> resultadoEsperado=new List<string>();
            resultadoEsperado.Add(nombreUsuario);
            List<string> resultadoObtenido = servicioJugadores.ObtenerJugadores().ToList();
            CollectionAssert.AreEqual(resultadoEsperado,resultadoObtenido);
        }

        [TestMethod]
        public void PruebaObtenerJugadoresFallida() 
        {
            ServicioJugadoresClient servicioJugadores = new ServicioJugadoresClient();
            List<string> resultadoObtenido = servicioJugadores.ObtenerJugadores().ToList();
            Assert.IsFalse(resultadoObtenido.Any());
        }

        [TestMethod]
        public void PruebaValidarNumeroJugadoresEnPartidaExitosa() 
        {
            ServicioSalaEsperaMock servicioSalaEsperaMock=new ServicioSalaEsperaMock();
            ServicioSalaDeEsperaClient servicioSalaDeEspera;
            servicioSalaDeEspera = new ServicioSalaDeEsperaClient(new InstanceContext(servicioSalaEsperaMock));            
            string codigoPartida = "87654321";
            List<JugadorContrato> jugadores = new List<JugadorContrato>();
            for (int i = 0; i < 10; i++) 
            {
                JugadorContrato jugadorContrato = new JugadorContrato
                {
                    NombreUsuario = "Jugador" +i,
                };
                servicioSalaDeEspera.ConectarJugador(codigoPartida,jugadorContrato);
            }
            ServicioJugadoresClient servicioJugadores = new ServicioJugadoresClient();
            bool resultadoValidacion=servicioJugadores.ValidarNumeroJugadoresEnPartida(codigoPartida);
            Assert.IsTrue(resultadoValidacion);                                    
        }

        [TestMethod]
        public void PruebaValidarNumeroJugadoresEnPartidaFallida()
        {
            ServicioJugadoresClient servicioJugadores = new ServicioJugadoresClient();
            string codigoPartida = "12345678";            
            bool resultadoObtenido = servicioJugadores.ValidarNumeroJugadoresEnPartida(codigoPartida);
            Assert.IsFalse(resultadoObtenido);
        }

        [TestMethod]
        public void PruebaVerificarConexionUsuarioExitosa() 
        {
            ServicioJugadoresClient servicioJugadores = new ServicioJugadoresClient();
            string nombreJugador = "Juan";
            servicioJugadores.ConectarJugadorJuego(nombreJugador);
            bool resultadoConexion=servicioJugadores.VerificarConexionUsuario(nombreJugador);
            Assert.IsTrue(resultadoConexion);
        }

        [TestMethod]
        public void PruebaVerificarConexionUsuarioFallida()
        {
            ServicioJugadoresClient servicioJugadores = new ServicioJugadoresClient();
            string nombreJugador = "Oscar";
            bool resultadoObtenido=servicioJugadores.VerificarConexionUsuario(nombreJugador);
            Assert.IsFalse(resultadoObtenido);
        }
    }

    public class ServicioSalaEsperaMock : IServicioSalaDeEsperaCallback
    {
        public void AbrirVentanaPartida(PreguntaContrato[] preguntasSeleccionadas, RespuestaContrato[] respuestasSeleccionadas)
        {            
            Console.WriteLine("Ventana de partida abierta.");
        }

        public void ActualizarListaJugadores(JugadorContrato[] jugadores)
        {            
            Console.WriteLine($"Lista de jugadores actualizada: {jugadores.Length} jugadores.");
        }

        public void NotificarExpulsion()
        {            
            Console.WriteLine("Notificación de expulsión.");
        }
    }

}