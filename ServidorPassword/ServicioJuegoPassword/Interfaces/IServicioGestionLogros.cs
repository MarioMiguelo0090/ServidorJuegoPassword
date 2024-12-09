using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para gestionar los logros de los jugadores.
    /// </summary>
    [ServiceContract]
    public interface IServicioGestionLogros
    {
        /// <summary>
        /// Registra un nuevo logro de un jugador específico.
        /// </summary>
        /// <param name="idJugador">Identificador del jugador</param>
        /// <param name="idLogro">Identificador del logro.</param>
        /// <returns>Retorna 1 si el logro es registrado.</returns>
        [OperationContract]
        int RegistrarNuevoLogroPorIdJugador(int idJugador, int idLogro);

        /// <summary>
        /// Verifica si un jugador ya tiene el registro de un logro específico.
        /// </summary>
        /// <param name="idJugador">Identificador del jugador.</param>
        /// <param name="idLogro">Identificador del logro.</param>
        /// <returns>Retorna 1 si el jugador tiene el logro registrado.</returns>
        [OperationContract]
        int VerificarRegistroEspecificoLogroPorIdJugador(int idJugador, int idLogro);

        /// <summary>
        /// Recupera los logros de un jugador.
        /// </summary>
        /// <param name="idJugador">Identificador del jugador.</param>
        /// <returns>Retorna una lista de identificadores de logros.</returns>
        [OperationContract]
        List<int> ObtenerIdLogrosPorIdJugador(int idJugador);

        /// <summary>
        /// Verifica si el catalogo de logros esta registrado en la base de datos.
        /// </summary>
        /// <returns>Retorna 1 si el catálogo esta completo.</returns>
        [OperationContract]
        int VerificarCatalogoDeLogros();

        /// <summary>
        /// Verifica si un jugador cumple con el primer logro del videojuego.
        /// </summary>
        /// <param name="idEstadistica">Identificador de la estadística del jugador.</param>
        /// <returns>Retorna 1 si el jugador cumple con el primer logro.</returns>
        [OperationContract]
        int VerificarPrimerLogroPorIdEstadistica(int idEstadistica);

        /// <summary>
        /// Verifica si un jugador cumple con el segundo logro del videojuego.
        /// </summary>
        /// <param name="idEstadistica">Identificador de la estadística del jugador.</param>
        /// <returns>Retorna 1 si el jugador cumple con el segundo logro.</returns>
        [OperationContract]
        int VerificarSegundoLogroPorIdEstadistica(int idEstadistica);

    }
}
