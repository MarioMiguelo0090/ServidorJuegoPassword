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
    [ServiceContract]
    public interface IServicioGestionPartida
    {
        [OperationContract]
        int RegistrarPartidaPorIdJugador(int idJugador, Partida partida);

        [OperationContract]
        int ActualizarEstadoPorIdPartida(int idPartida, string estado);

        [OperationContract]
        int ValidarCodigoPartida(string codigoPartida);

        [OperationContract]
        List<PreguntaContrato> ObtenerPreguntas();

        [OperationContract]
        List<Respuesta> ObtenerRespuestaPorIdPregunta(int idPregunta);

        [OperationContract]
        PartidaContrato RecuperarPartidaPorCodigo(string codigoPartida);

        [OperationContract]
        List<RespuestaContrato> RecuperarRespuestasPorIdPreguntas(List<int> idRespuestas);
    }


    [DataContract]
    public class PartidaContrato
    {
        [DataMember]
        public int IdPartida { get; set; }

        [DataMember]
        public string CodigoPartida { get; set; }

        [DataMember]
        public string ModoJuego { get; set; }

        [DataMember]
        public string EstadoPartida { get; set; }

        [DataMember]
        public int IdAnfitrion { get; set; }

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

    [DataContract]
    public class RespuestaContrato
    {
        [DataMember]
        public int IdRespuesta { get; set; }

        [DataMember]
        public string Respuesta { get; set; }

        [DataMember]
        public int FKIdPregunta { get; set; }

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

    [DataContract]
    public class PreguntaContrato 
    {
        [DataMember]
        public int IdPregunta { get; set; }

        [DataMember]
        public string Pregunta { get;set; }

        [DataMember]
        public string RespuestaCorrecta { get; set; }

        [DataMember]
        public int FKIdPartida {  get; set; }

        public static PreguntaContrato ConvertirDeAccesoADatos(Pregunta pregunta)
        {
            return new PreguntaContrato
            {
                IdPregunta=pregunta.idPregunta,
                Pregunta=pregunta.pregunta1,
                RespuestaCorrecta=pregunta.respuestaCorrecta,
                FKIdPartida=pregunta.FKidPartida,
            };
        }
    }
}
