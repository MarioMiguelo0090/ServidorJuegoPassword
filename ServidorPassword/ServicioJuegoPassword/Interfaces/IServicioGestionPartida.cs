using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        int ActualizarEstadoPorIdPartida(int idPartida,string estado);

        [OperationContract]
        int ValidarCodigoPartida(string codigoPartida);

        [OperationContract]
        List<Pregunta> ObtenerPreguntas();

        [OperationContract]
        List<Respuesta> ObtenerRespuestaPorIdPregunta(int idPregunta);
    }
}
