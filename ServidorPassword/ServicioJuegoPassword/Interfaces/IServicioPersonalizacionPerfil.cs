using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para personalizar el perfil de un jugador.
    /// </summary>
    [ServiceContract]
    public interface IServicioPersonalizacionPerfil
    {
        /// <summary>
        /// Edita el correo asociado a un jugador específico.
        /// </summary>
        /// <param name="idAcceso">Identificador de acceso del jugador.</param>
        /// <param name="correo">Nuevo correo a registrar</param>
        /// <returns>Retorna 1 si el nuevo correo es registrado.</returns>
        [OperationContract]
        int EditarCorreoPorIdAcceso(int idAcceso,string correo);

        /// <summary>
        /// Edita la descripción asociada a un jugador específico.
        /// </summary>
        /// <param name="idJugador">Identificador de jugador.</param>
        /// <param name="descripcion">Nueva descripción del jugador.</param>
        /// <returns>Retorna 1 si la nueva descripción es registrada.</returns>
        [OperationContract]
        int EditarDescripcionPorIdJugador(int idJugador,string descripcion);

        /// <summary>
        /// Edita el nombre de usuario asociado a un jugador específico.
        /// </summary>
        /// <param name="idJugador">Identificador del jugador.</param>
        /// <param name="nombreUsuario">Nuevo nombre de usuario del jugador.</param>
        /// <returns>Retorna 1 si el nuevo nombre de usuario es registrado.</returns>
        [OperationContract]
        int EditarNombreUsuarioPorIdJugador(int idJugador, string nombreUsuario);

        /// <summary>
        /// Edita la ruta de imagen asociada a un jugador específico.
        /// </summary>
        /// <param name="idJugador">Identificador del jugador.</param>
        /// <param name="rutaImagen">Nueva ruta de imagen del jugador.</param>
        /// <returns>Retorna 1 si la nueva ruta de imagen es registrada.</returns>
        [OperationContract]
        int EditarRutaImagenPorIdJugador(int idJugador, string rutaImagen);

        /// <summary>
        /// Edita la contraseña asociada a un jugador específico.
        /// </summary>
        /// <param name="idAcceso">Identificador de acceso de un jugador.</param>
        /// <param name="contrasenia">Nueva contraseña del jugador.</param>
        /// <returns></returns>
        [OperationContract]
        int EditarContraseniaPorIdAcceso(int idAcceso,string contrasenia);

        /// <summary>
        /// Recupera el ID de acceso de un jugador.
        /// </summary>
        /// <param name="correo">Correo elctrónico de un jugador.</param>
        /// <returns>Retorna el identificador de acceso del jugador.</returns>
        [OperationContract]
        int RecuperarIdAccesoPorCorreo(string correo);
    }
}
