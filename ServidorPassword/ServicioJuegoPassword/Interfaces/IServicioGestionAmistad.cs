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
        List<Amistad> ConsultarSolicitudesAmistadPorIdJugador(int idJugador);

        [OperationContract]
        List<Amistad> ConsultarAmistadesPorIdJugador(int idJugador);

        [OperationContract]
        int ConsultarIdJugadorPorCorreo(string correo);
    }
}
