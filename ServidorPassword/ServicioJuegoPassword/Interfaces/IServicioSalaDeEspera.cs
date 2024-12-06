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
    [ServiceContract(CallbackContract = typeof(IServicioSalaDeEsperaCallback))]
    public interface IServicioSalaDeEspera
    {
        [OperationContract(IsOneWay = true)]
        void ConectarJugador(string codigoPartida,JugadorContrato jugador);

        [OperationContract(IsOneWay = true)]
        void DesconectarJugador(string codigoPartida,JugadorContrato jugador);

        [OperationContract(IsOneWay = true)]
        void IniciarPartida(string codigoPartida,int cantidadPreguntas);

        [OperationContract(IsOneWay = true)]
        void ExpulsarJugador(string codigoPartida,JugadorContrato jugador);

        [OperationContract(IsOneWay = true)]
        void ExpulsarTodosJugadores(string codigoPartida);

    }


    [ServiceContract]
    public interface IServicioSalaDeEsperaCallback
    {
        [OperationContract]
        void ActualizarListaJugadores(List<JugadorContrato> jugadores);

        [OperationContract]
        void AbrirVentanaPartida(List<PreguntaContrato> preguntasSeleccionadas,List<RespuestaContrato> respuestasSeleccionadas);

        [OperationContract]
        void NotificarExpulsion();
    }

    
    [DataContract]
    public class JugadorContrato
    {
        [DataMember]
        public string NombreUsuario { get; set; }

        [DataMember]
        public string RutaImagen { get; set; }

        [DataMember]
        public int IdJugador { get; set; }

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
