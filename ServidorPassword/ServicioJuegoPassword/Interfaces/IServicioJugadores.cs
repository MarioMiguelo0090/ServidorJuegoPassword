using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato de los jugadores mientras estén en el videojuego.
    /// </summary>
    [ServiceContract]
    public interface IServicioJugadores
    {
        /// <summary>
        /// Conecta a un jugador al videojuego.
        /// </summary>
        /// <param name="jugador">Nombre de usuario del jugador.</param>
        /// <returns>Retorna 1 si el jugador pudo conectarse.</returns>
        [OperationContract]
        int ConectarJugadorJuego(string jugador);

        /// <summary>
        /// Desconecta a un jugador del videojuego.
        /// </summary>
        /// <param name="jugador">Nombre de usuario del jugador.</param>
        [OperationContract]
        void DesconectarJugadorJuego(string jugador);

        /// <summary>
        /// Recupera los jugadores conectados al videojuego.
        /// </summary>
        /// <returns>Retorna una lista de los nombres de usuario de los jugadores.</returns>
        [OperationContract]
        List<string> ObtenerJugadores();

        /// <summary>
        /// Verifica que un jugador este conectado en el videojuego.
        /// </summary>
        /// <param name="jugador">Nombre de usuario del jugador.</param>
        /// <returns>Retorna verdadero si el jugador se encuentra conectado.</returns>
        [OperationContract]
        bool VerificarConexionUsuario(string jugador);

        /// <summary>
        /// Valida que el número de jugadores en una partida sea menor a 10.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <returns>Verdadero si el número de jugadores es menor a 10.</returns>
        [OperationContract]
        bool ValidarNumeroJugadoresEnPartida(string codigoPartida);
    }

}