using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    [ServiceContract]
    public interface IServicioTemporizador
    {
        [OperationContract]
        void IniciarTemporizador(int numeroDePreguntas, int tiempoPorPregunta);

        [OperationContract]
        int ObtenerTiempoRestante();

        [OperationContract]
        int ObtenerPreguntasRestantes();

        [OperationContract]
        bool TemporizadorActivo();
    }
}
