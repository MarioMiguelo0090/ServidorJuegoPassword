using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    [ServiceContract]
    public interface IServicioJugadores
    {
        [OperationContract]
        int ConectarJugadorJuego(string jugador);

        [OperationContract]
        void DesconectarJugadorJuego(string jugador);

        [OperationContract]
        List<string> ObtenerJugadores();

        [OperationContract]
        bool VerificarConexionUsuario(string jugador);

        [OperationContract]
        bool ValidarNumeroJugadoresEnPartida(string codigoPartida);
    }

}