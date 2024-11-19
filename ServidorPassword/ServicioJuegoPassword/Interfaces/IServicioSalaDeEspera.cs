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
        [OperationContract]
        void ConectarJugador(string nombreUsuario, string rutaImagen);

        [OperationContract]
        void DesconectarJugador(string nombreUsuario);

        [OperationContract]
        List<JugadorContrato> ObtenerJugadoresConectados();
    }

    public interface IServicioSalaDeEsperaCallback
    {
        [OperationContract(IsOneWay = true)]
        void ActualizarListaJugadores(List<JugadorContrato> jugadores);
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
