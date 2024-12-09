using AccesoADatos;
using AccesoADatos.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para gestionar el acceso de los jugadores.
    /// </summary>
    [ServiceContract]
    public interface IServicioGestionAcceso
    {
        /// <summary>
        /// Registra a un nuevo jugador en el sistema.
        /// </summary>
        /// <param name="acceso">Contiene los datos de acceso a registrar del jugador</param>
        /// <param name="jugador">Contiene los datos generales del jugador</param>
        /// <returns>Retorna 1 cuando el registro es correcto</returns>
        [OperationContract]
        int RegistrarNuevoJugador(Acceso acceso, Jugador jugador);

        /// <summary>
        /// Valida que los datos de acceso coincidan con los registrados en la base de datos.
        /// </summary>
        /// <param name="acceso">Contiene los datos de acceso del jugador.</param>
        /// <returns>Retorna 1 cuando los datos de acceso coinciden.</returns>
        [OperationContract]
        int ValidarInicioDeSesion(Acceso acceso);        

        /// <summary>
        /// Valida si el nombre de usuario ya esta registrado en la base de datos.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario a buscar en la base de datos.</param>
        /// <returns>Retorna 1 si el nombre de usuario ya esta registrado.</returns>
        [OperationContract]
        int ValidarNombreUsuario(string nombreUsuario);

        /// <summary>
        /// Recupera la cuenta del jugador.
        /// </summary>
        /// <param name="correo">Correo electrónico de la cuenta a recuperar.</param>
        /// <returns>Recupera la cuenta correspondiente al correo proporcionado.</returns>
        [OperationContract]
        Cuenta RecuperarCuentaPorCorreo(string correo);

        /// <summary>
        /// Valida si el correo electrónico ya esta registrado en la base de datos.
        /// </summary>
        /// <param name="correo">Correo electrónico a buscar en la base de datos.</param>
        /// <returns>Retorna 1 si el correo ya esta registrado.</returns>
        [OperationContract]
        int ValidarPresenciaDeCorreo(string correo);

        /// <summary>
        /// Recupera la cuenta del jugador.
        /// </summary>
        /// <param name="idJugador">ID de jugador de la cuenta a recuperar.</param>
        /// <returns>Retorna la cuenta correspondiente al ID de jugador proporcionado.</returns>
        [OperationContract]
        Cuenta RecuperarCuentaPorIdJugador(int idJugador);

        /// <summary>
        /// Valida si el nombre de usuario o el correo electrónico ya estan registrados.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario a buscar en la base de datos.</param>
        /// <param name="correo">Correo electrónico a buscar en la base de datos.</param>
        /// <returns>Retorna 1 si el correo electrónico o el nombre de usuario ya estan registrados.</returns>
        [OperationContract]
        int ValidarPresenciaCuenta(string nombreUsuario, string correo);
    }
}
