using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para gestionar las partidas de un jugador.
    /// </summary>
    [ServiceContract]
    public interface IServicioGestionPartida
    {
        /// <summary>
        /// Registra una nueva partida para un jugador.
        /// </summary>
        /// <param name="idJugador">Identificador del jugador.</param>
        /// <param name="partida">Datos de la partida a registrar.</param>
        /// <returns>Retorna 1 si la partida es registrada.</returns>
        [OperationContract]
        int RegistrarPartidaPorIdJugador(int idJugador, Partida partida);

        /// <summary>
        /// Actualiza el estado de una partida.
        /// </summary>
        /// <param name="idPartida">Identificador de la partida.</param>
        /// <param name="estado">Nuevo estado de la partida.</param>
        /// <returns>Retorna 1 si el estado de la partida fue actualizado.</returns>
        [OperationContract]
        int ActualizarEstadoPorIdPartida(int idPartida, string estado);

        /// <summary>
        /// Valida que el código de la partida no este registrado.
        /// </summary>
        /// <param name="codigoPartida">Código de partida a buscar.</param>
        /// <returns>Retorna 1 si el código de la partida ya esta registrado.</returns>
        [OperationContract]
        int ValidarCodigoPartida(string codigoPartida);                

        /// <summary>
        /// Recupera una partida dado un códido.
        /// </summary>
        /// <param name="codigoPartida">Código de la partida a recuperar.</param>
        /// <returns>Partida correspondiente al código.</returns>
        [OperationContract]
        PartidaContrato RecuperarPartidaPorCodigo(string codigoPartida);                        

        /// <summary>
        /// Verifica que el catálogo de preguntas este registrado.
        /// </summary>
        /// <returns>Retorna 1 si el catálogo esta registrado.</returns>
        [OperationContract]
        int VerificarCatalogoCompletoPreguntas();

        /// <summary>
        /// Verifica que el catálogo de respuestas este registrado.
        /// </summary>
        /// <returns>Retorna 1 si el catálogo esta registrado.</returns>
        [OperationContract]
        int VerificarCatalogoCompletoRespuestas();

    }

    /// <summary>
    /// Representa a una partida.
    /// </summary>
    [DataContract]
    public class PartidaContrato
    {
        /// <summary>
        /// Idnetificador único de la partida.
        /// </summary>
        [DataMember]
        public int IdPartida { get; set; }

        /// <summary>
        /// Código único de la partida.
        /// </summary>
        [DataMember]
        public string CodigoPartida { get; set; }

        /// <summary>
        /// Modo de juego de la partida.
        /// </summary>
        [DataMember]
        public string ModoJuego { get; set; }

        /// <summary>
        /// Estado de la partida.
        /// </summary>
        [DataMember]
        public string EstadoPartida { get; set; }

        /// <summary>
        /// Identificador del jugador anfitrión de la partida.
        /// </summary>
        [DataMember]
        public int IdAnfitrion { get; set; }

        /// <summary>
        /// Convierte un objeto Partida de acceso a datos a PartidaContrato.
        /// </summary>
        /// <param name="partida">Partida del modelo de datos.</param>
        /// <returns>Partida convertida.</returns>
        public static PartidaContrato ConvertirDeAccesoADatos(Partida partida)
        {
            return new PartidaContrato
            {
                IdPartida = partida.idPartida,
                CodigoPartida = partida.codigoPartida,
                ModoJuego = partida.modoJuego,
                IdAnfitrion = partida.idAnfitrion,
                EstadoPartida = partida.estadoPartida,
            };
        }
    }

    /// <summary>
    /// Representa una respuesta relacionada a una pregunta.
    /// </summary>
    [DataContract]
    public class RespuestaContrato
    {
        /// <summary>
        /// Identificador de la respuesta.
        /// </summary>
        [DataMember]
        public int IdRespuesta { get; set; }

        /// <summary>
        /// Respuesta registrada.
        /// </summary>
        [DataMember]
        public string Respuesta { get; set; }

        /// <summary>
        /// Identificador de la pregunta asociada.
        /// </summary>
        [DataMember]
        public int FKIdPregunta { get; set; }

        /// <summary>
        /// Convierte un objeto Respuesta del modelo de datos a RespuestaContrato. 
        /// </summary>
        /// <param name="respuesta">Respuesta del modelo de datos.</param>
        /// <returns>Respuesta convertida.</returns>
        public static RespuestaContrato ConvertirDeAccesoADatos(Respuesta respuesta) 
        {
            return new RespuestaContrato 
            {
                IdRespuesta = respuesta.idRespuesta,
                Respuesta=respuesta.respuesta1,
                FKIdPregunta=respuesta.FKidPregunta,
            };
        }
    }

    /// <summary>
    /// Representa una pregunta en el videojuego.
    /// </summary>
    [DataContract]
    public class PreguntaContrato 
    {
        /// <summary>
        /// Identificador de pregunta.
        /// </summary>
        [DataMember]
        public int IdPregunta { get; set; }

        /// <summary>
        /// Pregunta a realizar.
        /// </summary>
        [DataMember]
        public string Pregunta { get;set; }

        /// <summary>
        /// Respuesta correcta a la pregunta.
        /// </summary>
        [DataMember]
        public string RespuestaCorrecta { get; set; }        

        /// <summary>
        /// Convierte un objeto Pregunta del modelo de datos a PreguntaContrato.
        /// </summary>
        /// <param name="pregunta">Pregunta del modelo de datos.</param>
        /// <returns>Pregunta convertida.</returns>
        public static PreguntaContrato ConvertirDeAccesoADatos(Pregunta pregunta)
        {
            return new PreguntaContrato
            {
                IdPregunta=pregunta.idPregunta,
                Pregunta=pregunta.pregunta1,
                RespuestaCorrecta=pregunta.respuestaCorrecta,                
            };
        }
    }
}
