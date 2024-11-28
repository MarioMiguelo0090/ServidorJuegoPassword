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


        public void ConectarJugador(string codigoPartida, JugadorContrato jugador)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioSalaDeEsperaCallback>();
            if (!_jugadoresEnPartida.ContainsKey(codigoPartida)) 
            {
                _jugadoresEnPartida[codigoPartida] = new List<IServicioSalaDeEsperaCallback>();
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
            foreach (var callback in _jugadoresEnPartida[codigoPartida])
            {
                callback.ActualizarListaJugadores(_jugadores[codigoPartida]);
            }
        }

        public void DesconectarJugador(string codigoPartida, JugadorContrato jugador)
        {
            var cliente = OperationContext.Current.GetCallbackChannel<IServicioSalaDeEsperaCallback>();            
            if (_jugadoresEnPartida.ContainsKey(codigoPartida))
            {                
                var jugadorAEliminar = _jugadores[codigoPartida].FirstOrDefault(j => j.NombreUsuario == jugador.NombreUsuario);
                if (jugadorAEliminar != null)
                {
                    _jugadores[codigoPartida].Remove(jugadorAEliminar);
                }             
                if (_jugadoresEnPartida[codigoPartida].Contains(cliente))
                {
                    _jugadoresEnPartida[codigoPartida].Remove(cliente);
                }                
                foreach (var callback in _jugadoresEnPartida[codigoPartida])
                {
                    callback.ActualizarListaJugadores(_jugadores[codigoPartida]);
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
