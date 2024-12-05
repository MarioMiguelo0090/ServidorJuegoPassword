using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJuegoPassword.Interfaces
{
    [ServiceContract]
    public interface IServicioGestionLogros
    {
        [OperationContract]
        int RegistrarNuevoLogroPorIdJugador(int idJugador, int idLogro);

        [OperationContract]
        int VerificarRegistroEspecificoLogroPorIdJugador(int idJugador, int idLogro);

        [OperationContract]
        List<int> ObtenerIdLogrosPorIdJugador(int idJugador);

        [OperationContract]
        int VerificarCatalogoDeLogros();

        [OperationContract]
        int VerificarPrimerLogroPorIdEstadistica(int idEstadistica);

        [OperationContract]
        int VerificarSegundoLogroPorIdEstadistica(int idEstadistica);

    }
}
