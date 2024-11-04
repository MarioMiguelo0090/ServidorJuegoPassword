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

        public List<Pregunta> ObtenerPreguntas()
        {
            return _gestionPartida.RecuperarPreguntas();
        }

        public List<Respuesta> ObtenerRespuestaPorIdPregunta(int idPregunta)
        {
            return _gestionPartida.RecuperarRespuestasPorIdPregunta(idPregunta);
        }
    }
            
}
