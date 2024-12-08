using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaServicioJuegoPassword.ServidorPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static PruebaServicioJuegoPassword.PruebaServicioChat;

namespace PruebaServicioJuegoPassword
{
    public class PruebaServicioSalaDeEspera
    {
        public class ServicioSalaDeEsperaMock : IServicioSalaDeEsperaCallback
        {
            public bool VentanaAbierta {  get; set; }
            public bool ListaJugadoresRecibida { get; set; }
            public bool NotificacionExpulsionRecibida { get; set; }

            public void AbrirVentanaPartida(PreguntaContrato[] preguntasSeleccionadas, RespuestaContrato[] respuestasSeleccionadas)
            {
                VentanaAbierta = true;
            }

            public void ActualizarListaJugadores(JugadorContrato[] jugadores)
            {
                ListaJugadoresRecibida = true;
            }

            public void NotificarExpulsion()
            {
                NotificacionExpulsionRecibida = true;
            }
        }

        [TestClass]
        public class PruebaSalaDeEspera
        {
            private static ServicioSalaDeEsperaClient _servicioSalaEspera;
            private static ServicioSalaDeEsperaMock _servicioSalaEsperaMock;

            [ClassInitialize]
            public static void ConfigurarSalaDeEspera(TestContext contextoPrueba) 
            {
                _servicioSalaEsperaMock=new ServicioSalaDeEsperaMock();
                _servicioSalaEspera = new ServicioSalaDeEsperaClient(new InstanceContext(_servicioSalaEsperaMock));                
            }

            [TestMethod]
            public async Task PruebaConectarJugadorExitosa()
            {
                _servicioSalaEsperaMock.ListaJugadoresRecibida = false;
                string codigoPartida = "01010101";
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Jesus",
                };
                _servicioSalaEspera.ConectarJugador(codigoPartida,jugador);
                await Task.Delay(5000);
                Assert.IsTrue(_servicioSalaEsperaMock.ListaJugadoresRecibida);
            }

            [TestMethod]
            public void PruebaConectarJugadorFallida() 
            {
                _servicioSalaEsperaMock.ListaJugadoresRecibida = false;
                string codigoPartida = "02020202";
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Chris",
                };
                _servicioSalaEspera.ConectarJugador(codigoPartida, jugador);
                Assert.IsFalse(_servicioSalaEsperaMock.ListaJugadoresRecibida);
            }

            [TestMethod]
            public async Task PruebaDesconectarJugadorExitosa() 
            {
                _servicioSalaEsperaMock.ListaJugadoresRecibida = false;
                string codigoPartida = "03030303";
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Jesus",
                };
                _servicioSalaEspera.ConectarJugador(codigoPartida, jugador);
                await Task.Delay(1000);
                _servicioSalaEsperaMock.ListaJugadoresRecibida = false;
                _servicioSalaEspera.DesconectarJugador(codigoPartida, jugador);
                await Task.Delay(1000);
                Assert.IsTrue(_servicioSalaEsperaMock.ListaJugadoresRecibida);
            }

            [TestMethod]
            public void PruebaDesconectarJugadorFallida() 
            {
                _servicioSalaEsperaMock.ListaJugadoresRecibida = false;
                string codigoPartida = "04040404";
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Jesus",
                };
                _servicioSalaEspera.DesconectarJugador(codigoPartida, jugador);
                Assert.IsFalse(_servicioSalaEsperaMock.ListaJugadoresRecibida);
            }

            [TestMethod]
            public async Task PruebaExpulsarJugadorExitosa() 
            {
                _servicioSalaEsperaMock.NotificacionExpulsionRecibida = false;
                string codigoPartida = "05050505";
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Jesus",
                };
                _servicioSalaEspera.ConectarJugador(codigoPartida, jugador);
                await Task.Delay(5000);
                _servicioSalaEspera.ExpulsarJugador(codigoPartida,jugador);
                await Task.Delay(5000);
                Assert.IsTrue(_servicioSalaEsperaMock.NotificacionExpulsionRecibida);
            }


            [TestMethod]
            public void PruebaExpulsarJugadorFallida() 
            {
                _servicioSalaEsperaMock.NotificacionExpulsionRecibida = false;
                string codigoPartida = "06060606";
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Jesus",
                };                
                _servicioSalaEspera.ExpulsarJugador(codigoPartida, jugador);                
                Assert.IsFalse(_servicioSalaEsperaMock.NotificacionExpulsionRecibida);
            }

            [TestMethod]
            public async Task PruebaExpulsarTodosJugadoresExitosa() 
            {
                _servicioSalaEsperaMock.NotificacionExpulsionRecibida = false;
                string codigoPartida = "07070707";
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Jesus",
                };
                _servicioSalaEspera.ConectarJugador(codigoPartida, jugador);
                await Task.Delay(5000);
                _servicioSalaEspera.ExpulsarTodosJugadores(codigoPartida);
                await Task.Delay(5000);
                Assert.IsTrue(_servicioSalaEsperaMock.NotificacionExpulsionRecibida);
            }

            [TestMethod]
            public void PruebaExpulsarTodosJugadoresFallida() 
            {
                _servicioSalaEsperaMock.NotificacionExpulsionRecibida = false;
                string codigoPartida = "08080808";
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Jesus",
                };
                _servicioSalaEspera.ExpulsarTodosJugadores(codigoPartida);                
                Assert.IsFalse(_servicioSalaEsperaMock.NotificacionExpulsionRecibida);
            }

            [TestMethod]
            public async Task PruebaIniciarPartidaExitosa() 
            {
                _servicioSalaEsperaMock.VentanaAbierta = false;
                string codigoPartida = "09090909";
                int cantidadPreguntas = 10;
                JugadorContrato jugador = new JugadorContrato()
                {
                    NombreUsuario = "Jesus",
                };
                _servicioSalaEspera.ConectarJugador(codigoPartida, jugador);                
                _servicioSalaEspera.IniciarPartida(codigoPartida,cantidadPreguntas);
                await Task.Delay(5000);
                Assert.IsTrue(_servicioSalaEsperaMock.VentanaAbierta);
            }

            [TestMethod]
            public void PruebaIniciarPartidaFallida() 
            {
                _servicioSalaEsperaMock.VentanaAbierta = false;
                string codigoPartida = "10101010";
                int cantidadPreguntas = 10;
                _servicioSalaEspera.IniciarPartida(codigoPartida, cantidadPreguntas);
                Assert.IsFalse(_servicioSalaEsperaMock.VentanaAbierta);
            }

        }
    }
}
