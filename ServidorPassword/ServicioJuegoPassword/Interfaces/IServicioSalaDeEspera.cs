using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para las operaciones mientras los jugadores están en la sala de espera.
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IServicioSalaDeEsperaCallback))]
    public interface IServicioSalaDeEspera
    {
        /// <summary>
        /// Conecta a un jugador a una partida específica.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <param name="jugador">Datos del jugador.</param>
        [OperationContract(IsOneWay = true)]
        void ConectarJugador(string codigoPartida,JugadorContrato jugador);

        /// <summary>
        /// Desconecta a un jugador de una partida.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <param name="jugador">Datos del jugador.</param>
        [OperationContract(IsOneWay = true)]
        void DesconectarJugador(string codigoPartida,JugadorContrato jugador);

        /// <summary>
        /// Recupera las preguntas y respuestas para iniciar una partida.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <param name="cantidadPreguntas">Cantidad de preguntas a recuperar.</param>
        [OperationContract(IsOneWay = true)]
        void IniciarPartida(string codigoPartida,int cantidadPreguntas);

        /// <summary>
        /// Expulsa a un jugador de una partida.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        /// <param name="jugador">Datos del jugador.</param>
        [OperationContract(IsOneWay = true)]
        void ExpulsarJugador(string codigoPartida,JugadorContrato jugador);

        /// <summary>
        /// Expulsa a todos los jugadores de una partida específica.
        /// </summary>
        /// <param name="codigoPartida">Código de partida único.</param>
        [OperationContract(IsOneWay = true)]
        void ExpulsarTodosJugadores(string codigoPartida);

    }

    /// <summary>
    /// Contrato de devolución de llamada para notificar cambios a los clientes en la sala de espera.
    /// </summary>
    [ServiceContract]
    public interface IServicioSalaDeEsperaCallback
    {
        /// <summary>
        /// Notifica a los jugadores sobre los demás jugadores que se encuentran en una misma sala de espera.
        /// </summary>
        /// <param name="jugadores">Lista de jugadores en la sala de espera.</param>
        [OperationContract]
        void ActualizarListaJugadores(List<JugadorContrato> jugadores);

        /// <summary>
        /// Notifica a los clientes que la partida ha iniciado proporcionando preguntas y respuestas.
        /// </summary>
        /// <param name="preguntasSeleccionadas">Lista de preguntas seleccionadas para la partida.</param>
        /// <param name="respuestasSeleccionadas">Lista de respuestas seleccionadas para la partida.</param>
        [OperationContract]
        void AbrirVentanaPartida(List<PreguntaContrato> preguntasSeleccionadas,List<RespuestaContrato> respuestasSeleccionadas);

        /// <summary>
        /// Notifica a un jugador que ha sido expulsado de una partida.
        /// </summary>
        [OperationContract]
        void NotificarExpulsion();
    }

    /// <summary>
    /// Representa los datos de un jugador.
    /// </summary>
    [DataContract]
    public class JugadorContrato
    {
        /// <summary>
        /// Nombre de usuario del jugador.
        /// </summary>
        [DataMember]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Ruta de la imagen de perfil del jugador.
        /// </summary>
        [DataMember]
        public string RutaImagen { get; set; }

        /// <summary>
        /// Identificador´del jugador.
        /// </summary>
        [DataMember]
        public int IdJugador { get; set; }

        /// <summary>
        /// Convierte un Jugador del modelo de datos a JugadorContrato.
        /// </summary>
        /// <param name="jugador">Jugador del modelo de datos.</param>
        /// <returns>Jugador convertido.</returns>
        public static JugadorContrato ConvertirDeAccesoADatos(Jugador jugador) 
        {
            return new JugadorContrato 
            {
                NombreUsuario=jugador.nombreUsuario,
                IdJugador=jugador.idJugador,
            };
        }
    }    

}
