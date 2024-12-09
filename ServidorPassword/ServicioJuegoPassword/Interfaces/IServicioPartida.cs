using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato de operaciones realizadas mientras se juega una partida.
    /// </summary>
    [ServiceContract]
    public interface IServicioPartida
    {
        /// <summary>
        /// Registra la cantidad de preguntas que serán realizadas en la partida.
        /// </summary>
        /// <param name="codigoPartida">Código único de partida.</param>
        /// <param name="numeroPreguntas">Número de preguntas a realizar.</param>
        [OperationContract]
        void InicializarPartida(string codigoPartida, int numeroPreguntas);

        /// <summary>
        /// Registra a los jugadores de una partida específica.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <param name="jugadores">Lista de jugadores a registrar.</param>
        [OperationContract]
        void ConfigurarJugadores(string codigoPartida, List<string> jugadores);

        /// <summary>
        /// Evalua el puntaje que se le debe dar a un jugador respecto a una pregunta.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <param name="nombreUsuario">Nombre de usuario de un jugador.</param>
        /// <param name="numeroPregunta">Número de pregunta específica.</param>
        [OperationContract]
        void EvaluarPregunta(string codigoPartida, string nombreUsuario, int numeroPregunta);

        /// <summary>
        /// Resta el puntaje de un jugador en una partida específica.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <param name="nombreUsuario">Nombre de usuario del jugador.</param>
        [OperationContract]
        void RestarPuntaje(string codigoPartida, string nombreUsuario);

        /// <summary>
        /// Obtiene el puntaje de un jugador en una partida específica.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <param name="nombreUsuario">Nombre de usuario del jugador.</param>
        /// <returns>Punatje del jugador en la partida.</returns>
        [OperationContract]
        int ObtenerPuntaje(string codigoPartida, string nombreUsuario);

        /// <summary>
        /// Obtiene el jugador con puntuación más alta de una partida.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <returns>Nombre de usuario del jugador ganador.</returns>
        [OperationContract]
        string ObtenerGanador(string codigoPartida);
    }
}