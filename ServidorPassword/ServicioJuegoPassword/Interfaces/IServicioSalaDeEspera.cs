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
        void IniciarPartida(string codigoPartida);
    }

    public interface IServicioSalaDeEsperaCallback
    {
        [OperationContract]
        void ActualizarListaJugadores(List<JugadorContrato> jugadores);

        [OperationContract]
        void AbrirVentanaPartida();
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
    }    

}
