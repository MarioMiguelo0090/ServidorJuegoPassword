using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioPartida
    {
        private static Dictionary<string, Dictionary<string, int>> _puntajeJugadores = new Dictionary<string, Dictionary<string, int>>();
        private static Dictionary<string, Dictionary<int,bool>> _preguntasRegistradas=new Dictionary<string, Dictionary<int,bool>>();

        public void ConfigurarJugadores(string codigoPartida, List<string> jugadores)
        {
            if (!_puntajeJugadores.ContainsKey(codigoPartida)) 
            {
                Dictionary<string, int> nombresUsuario= new Dictionary<string, int>();
                for (int i = 0; i < jugadores.Count; i++) 
                {
                    nombresUsuario.Add(jugadores[i], 0);
                }
                _puntajeJugadores[codigoPartida] = nombresUsuario;
            }
        }

        public void InicializarPartida(string codigoPartida, int numeroPreguntas)
        {
            if (!_preguntasRegistradas.ContainsKey(codigoPartida)) 
            {
                Dictionary<int, bool> preguntas = new Dictionary<int, bool>();
                for (int i = 1; i <= numeroPreguntas; i++)
                {
                    preguntas.Add(i, false);
                }
                _preguntasRegistradas[codigoPartida] = preguntas;
            }
        }

        public void EvaluarPregunta(string codigoPartida, string nombreUsuario, int numeroPregunta) 
        {
            if (_preguntasRegistradas.ContainsKey(codigoPartida))
            {
                var preguntas = _preguntasRegistradas[codigoPartida];
                if (preguntas.ContainsKey(numeroPregunta)) 
                {
                    if (!preguntas[numeroPregunta])
                    {
                        preguntas[numeroPregunta] = true;
                        SumarPuntaje(codigoPartida, nombreUsuario, 20);
                    }
                    else 
                    {
                        SumarPuntaje(codigoPartida, nombreUsuario, 10);
                    }
                }
                
            }
        }

        public int ObtenerPuntaje(string codigoPartida, string nombreUsuario)
        {
            int puntaje = 0;
            var puntajeJugadores = _puntajeJugadores[codigoPartida];
            if (puntajeJugadores.ContainsKey(nombreUsuario))
            {
                puntaje=puntajeJugadores[nombreUsuario];
            }
            return puntaje;
        }

        public void RestarPuntaje(string codigoPartida, string nombreUsuario)
        {
            var puntajeJugadores = _puntajeJugadores[codigoPartida];
            if (puntajeJugadores.ContainsKey(nombreUsuario))
            {
                puntajeJugadores[nombreUsuario] -=10;
            }
        }

        public void SumarPuntaje(string codigoPartida, string nombreUsuario, int cantidadASumar)
        {
            var puntajeJugadores = _puntajeJugadores[codigoPartida];
            if (puntajeJugadores.ContainsKey(nombreUsuario)) 
            {
                puntajeJugadores[nombreUsuario]+=cantidadASumar;
            }
        }

        public bool ObtenerGanador(string codigoPartida, string nombreUsuario) 
        {
            var puntajeJugadores = _puntajeJugadores[codigoPartida];                       
            int puntajeJugador = puntajeJugadores[nombreUsuario];                
            int puntajeMaximo = puntajeJugadores.Values.Max();                                            
            return puntajeJugador == puntajeMaximo;
        }
    }
}
