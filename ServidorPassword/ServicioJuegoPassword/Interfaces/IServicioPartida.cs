using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    [ServiceContract]
    public interface IServicioPartida
    {
        [OperationContract]
        void InicializarPartida(string codigoPartida, int numeroPreguntas);

        [OperationContract]
        void ConfigurarJugadores(string codigoPartida, List<string> jugadores);

        [OperationContract]
        void EvaluarPregunta(string codigoPartida,string nombreUsuario,int numeroPregunta);           

        [OperationContract]
        void RestarPuntaje(string codigoPartida,string nombreUsuario);

        [OperationContract]
        int ObtenerPuntaje(string codigoPartida,string nombreUsuario);

        [OperationContract]
        bool ObtenerGanador(string codigoPartida, string nombreUsuario);
    }
}
