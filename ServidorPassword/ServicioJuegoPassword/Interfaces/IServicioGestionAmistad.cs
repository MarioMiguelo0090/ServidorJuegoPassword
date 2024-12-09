using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para gestionar las amistades entre jugadores.
    /// </summary>
    [ServiceContract]
    public interface IServicioGestionAmistad
    {
        /// <summary>
        /// Registra una nueva amistad entre dos jugadores
        /// </summary>
        /// <param name="amistad">Contiene la información de la relación de amistad.</param>
        /// <returns>Retorna 1 si la amistad fue registrada.</returns>
        [OperationContract]
        int RegistrarAmistad(Amistad amistad);

        /// <summary>
        /// Registra la respuesta de amistad enviada por otro jugador.
        /// </summary>
        /// <param name="amistad">Contiene la respuesta de la solicitud de amistad.</param>
        /// <returns>Retorna 1 si la respuesta pudo registrarse.</returns>
        [OperationContract]
        int ResponderSolicitudAmistad(Amistad amistad);

        /// <summary>
        /// Consulta las solicitudes de amistad de un jugador.
        /// </summary>
        /// <param name="idJugador">Identificador del jugador.</param>
        /// <returns>Retorna la lista con los identificadores de las solicitudes de amistad.</returns>
        [OperationContract]
        List<int> ConsultarSolicitudesAmistadPorIdJugador(int idJugador);

        /// <summary>
        /// Consulta las solicitudes de amistad de un jugador.
        /// </summary>
        /// <param name="idJugador">Identificador del jugador.</param>
        /// <returns>Lista de jugadores que enviaron una solicitud de amistad al jugador específico.</returns>
        [OperationContract]
        List<JugadorContrato> ConsultarAmistadesPorIdJugador(int idJugador);

        /// <summary>
        /// Consulta el ID de un jugador usando su correo electrónico.
        /// </summary>
        /// <param name="correo">Correo electrónico del jugador.</param>
        /// <returns>Retorna el ID del jugador que coincide con el correo electrónico.</returns>
        [OperationContract]
        int ConsultarIdJugadorPorCorreo(string correo);

        /// <summary>
        /// Recupera los nombres de usuario correspondientes a una lista de ID de jugadores.
        /// </summary>
        /// <param name="idJugadores">Lista de identificadores de jugadores.</param>
        /// <returns>Lista de nombres de usuario.</returns>
        [OperationContract]
        List<string> ObtenerNombresDeUsuarioPorIdJugadores(List<int> idJugadores);

        /// <summary>
        /// Valida la existencia de una amistad entre dos jugadores.
        /// </summary>
        /// <param name="idJugadorUno">Identificador del primer jugador.</param>
        /// <param name="idJugadorDos">Identificador del segundo jugador.</param>
        /// <returns>Retorna 1 si existe una amistad registrada.</returns>
        [OperationContract]
        int ValidarExistenciaAmistadPorIdJugadores(int idJugadorUno,int idJugadorDos);

        /// <summary>
        /// Recupera el identificador de una amistad entre dos jugadores.
        /// </summary>
        /// <param name="idJugadorUno">Identificador del primer jugador.</param>
        /// <param name="idJugadorDos">Identificador del segundo jugador.</param>
        /// <returns>Retorna el identificador de la amistad.</returns>
        [OperationContract]
        int RecuperarIdAmistadPorIdJugadores(int idJugadorUno,int idJugadorDos);        
    }
}
