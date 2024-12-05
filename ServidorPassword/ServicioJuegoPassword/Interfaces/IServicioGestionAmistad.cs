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
    public interface IServicioGestionAmistad
    {
        [OperationContract]
        int RegistrarAmistad(Amistad amistad);

        [OperationContract]
        int ResponderSolicitudAmistad(Amistad amistad);

        [OperationContract]
        List<int> ConsultarSolicitudesAmistadPorIdJugador(int idJugador);

        [OperationContract]
        List<JugadorContrato> ConsultarAmistadesPorIdJugador(int idJugador);

        [OperationContract]
        int ConsultarIdJugadorPorCorreo(string correo);

        [OperationContract]
        List<string> ObtenerNombresDeUsuarioPorIdJugadores(List<int> idJugadores);

        [OperationContract]
        int ValidarExistenciaAmistadPorIdJugadores(int idJugadorUno,int idJugadorDos);

        [OperationContract]
        int RecuperarIdAmistadPorIdJugadores(int idJugadorUno,int idJugadorDos);        
    }
}
