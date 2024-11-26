using AccesoADatos;
using ServicioJuegoPassword.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Servicios
{
    public partial class ServicioPassword : IServicioGestionPartida
    {
        private GestionPartida _gestionPartida=new GestionPartida();

        public int RegistrarPartidaPorIdJugador(int idJugador, Partida partida)
        {
            return _gestionPartida.RegistrarNuevaPartidaPorIdJugador(idJugador,partida);
        }
        public int ActualizarEstadoPorIdPartida(int idPartida, string estado)
        {
            return _gestionPartida.ActualizarEstadoDePartidaPorIdPartida(idPartida,estado);
        }

        public int ValidarCodigoPartida(string codigoPartida)
        {
            return _gestionPartida.ValidarInexistenciaCodigoPartida(codigoPartida);
        }

        public List<PreguntaContrato> ObtenerPreguntas()
        {
            var preguntasObtenidas=_gestionPartida.RecuperarPreguntas();
            List<PreguntaContrato> preguntasFinales=new List<PreguntaContrato>();
            foreach (var pregunta in preguntasObtenidas) 
            {
                PreguntaContrato preguntaContrato=PreguntaContrato.ConvertirDeAccesoADatos(pregunta);
                preguntasFinales.Add(preguntaContrato);
            }
            return preguntasFinales;
        }

        public List<Respuesta> ObtenerRespuestaPorIdPregunta(int idPregunta)
        {
            return _gestionPartida.RecuperarRespuestasPorIdPregunta(idPregunta);
        }

        public PartidaContrato RecuperarPartidaPorCodigo(string codigoPartida)
        {
            var datosPartida = _gestionPartida.ObtenerPartidaPorCodigoPartida(codigoPartida);
            return PartidaContrato.ConvertirDeAccesoADatos(datosPartida);             
        }

        public List<RespuestaContrato> RecuperarRespuestasPorIdPreguntas(List<int> idPreguntas)
        {
            var respuestasObtenidas = _gestionPartida.ObtenerRespuestasPorIdPreguntas(idPreguntas);
            List<RespuestaContrato> respuestasFinales = new List<RespuestaContrato>();
            foreach (var respuesta in respuestasObtenidas)
            {
                RespuestaContrato respuestaContrato = RespuestaContrato.ConvertirDeAccesoADatos(respuesta);
                respuestasFinales.Add(respuestaContrato);
            }
            return respuestasFinales;
        }

        public List<PreguntaContrato> SeleccionarPreguntasAlAzar(int cantidadPreguntas)
        {
            List<PreguntaContrato> preguntasObtenidas = ObtenerPreguntas();
            List<PreguntaContrato> preguntasSeleccionadas = new List<PreguntaContrato>();
            Random aleatorio = new Random();
            HashSet<int> indicesSeleccionados = new HashSet<int>();
            while (preguntasSeleccionadas.Count < cantidadPreguntas)
            {
                int indiceAleatorio = aleatorio.Next(preguntasObtenidas.Count);
                if (!indicesSeleccionados.Contains(indiceAleatorio))
                {
                    indicesSeleccionados.Add(indiceAleatorio);
                    preguntasSeleccionadas.Add(preguntasObtenidas[indiceAleatorio]);
                }
            }
            return preguntasSeleccionadas;
        }

        public List<int> ObtenerIdPreguntas(List<PreguntaContrato> preguntasSeleccionadas) 
        {
            List<int> idPreguntas = new List<int>();
            foreach (var pregunta in preguntasSeleccionadas) 
            {
                idPreguntas.Add(pregunta.IdPregunta);
            }
            return idPreguntas;
        }        
    }
            
}
