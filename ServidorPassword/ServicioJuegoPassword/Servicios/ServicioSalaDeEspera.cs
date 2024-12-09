using AccesoADatos;
using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioSalaDeEspera
    {
        private static Dictionary<string, List<IServicioSalaDeEsperaCallback>> _jugadoresEnPartida = new Dictionary<string, List<IServicioSalaDeEsperaCallback>>();
        private static Dictionary<string, List<JugadorContrato>> _jugadores= new Dictionary<string, List<JugadorContrato>>();
        private static Dictionary<string, IServicioSalaDeEsperaCallback> _retrollamadaPorJugador = new Dictionary<string, IServicioSalaDeEsperaCallback>();

        public void ConectarJugador(string codigoPartida, JugadorContrato jugador)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioSalaDeEsperaCallback>();
            if (!_jugadoresEnPartida.ContainsKey(codigoPartida)) 
            {
                _jugadoresEnPartida[codigoPartida] = new List<IServicioSalaDeEsperaCallback>();
            }
            if (!_retrollamadaPorJugador.ContainsKey(jugador.NombreUsuario))
            {
                _retrollamadaPorJugador[jugador.NombreUsuario] = cliente;
            }
            if (!_jugadoresEnPartida[codigoPartida].Contains(cliente)) 
            {
                _jugadoresEnPartida[codigoPartida].Add(cliente);
                if (!_jugadores.ContainsKey(codigoPartida))
                {
                    _jugadores[codigoPartida] = new List<JugadorContrato>();
                }
                _jugadores[codigoPartida].Add(jugador);
            }            
            foreach (var retrollamada in _jugadoresEnPartida[codigoPartida])
            {
                retrollamada.ActualizarListaJugadores(_jugadores[codigoPartida]);
            }
        }

        public void DesconectarJugador(string codigoPartida, JugadorContrato jugador)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioSalaDeEsperaCallback>();            
            if (_jugadoresEnPartida.ContainsKey(codigoPartida))
            {                
                var jugadorAEliminar = _jugadores[codigoPartida].Find(j => j.NombreUsuario == jugador.NombreUsuario);
                if (jugadorAEliminar != null)
                {
                    _jugadores[codigoPartida].Remove(jugadorAEliminar);
                }             
                if (_jugadoresEnPartida[codigoPartida].Contains(cliente))
                {
                    _jugadoresEnPartida[codigoPartida].Remove(cliente);
                }
                if (_retrollamadaPorJugador.ContainsKey(jugador.NombreUsuario))
                {
                    _retrollamadaPorJugador.Remove(jugador.NombreUsuario);
                }
                foreach (var retrollamadaJugador in _jugadoresEnPartida[codigoPartida])
                {
                    retrollamadaJugador.ActualizarListaJugadores(_jugadores[codigoPartida]);
                }                                
            }
        }

        public void ExpulsarJugador(string codigoPartida, JugadorContrato jugador) 
        {
            if (_jugadoresEnPartida.ContainsKey(codigoPartida) && _retrollamadaPorJugador.ContainsKey(jugador.NombreUsuario))
            {
                var retrollamadaJugador = _retrollamadaPorJugador[jugador.NombreUsuario];
                retrollamadaJugador.NotificarExpulsion();
            }
        }

        public void ExpulsarTodosJugadores(string codigoPartida) 
        {
            if (_jugadoresEnPartida.ContainsKey(codigoPartida))
            {
                var copiaRetrollamadas = _jugadoresEnPartida[codigoPartida].ToList();
                foreach (var retrollamada in copiaRetrollamadas)
                {
                    retrollamada.NotificarExpulsion();
                }
            }
        }

        public void IniciarPartida(string codigoPartida, int cantidadPreguntas)
        {
            if (_jugadoresEnPartida.ContainsKey(codigoPartida))
            {
                List<PreguntaContrato> preguntasObtenidas = SeleccionarPreguntasAlAzar(cantidadPreguntas);
                List<int> idPreguntasObtenidas = ObtenerIdPreguntas(preguntasObtenidas);
                List<RespuestaContrato> respuestasObtenidas = RecuperarRespuestasPorIdPreguntas(idPreguntasObtenidas);
                Parallel.ForEach(_jugadoresEnPartida[codigoPartida], retrollamada =>
                {
                    retrollamada.AbrirVentanaPartida(preguntasObtenidas, respuestasObtenidas);
                });
            }
        }

    }
}
