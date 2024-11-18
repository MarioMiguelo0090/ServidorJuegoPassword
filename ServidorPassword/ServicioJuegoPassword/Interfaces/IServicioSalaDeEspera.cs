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
        void RegistrarJugador(JugadorContrato jugador);

        [OperationContract]
        List<JugadorContrato> ObtenerJugadores();
    }


    public interface IServicioSalaDeEsperaCallback 
    {
        [OperationContract(IsOneWay = true)]
        void JugadorConectado(JugadorContrato jugador);
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
